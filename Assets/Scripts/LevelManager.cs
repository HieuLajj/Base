using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HieuLajj{

	public class SquareBlocks{
		public SquareTypes block;
		public SquareTypes obstacle;
	}

	public enum GameState {
		Map,
		PrepareGame,
		PrepareBoosts,
		Playing,
		Highscore,
		GameOver,
		Pause,
		PreWinAnimations,
		Win,
		WaitForPopup,
		WaitAfterClose,
		BlockedGame,
		Tutorial,
		PreTutorial,
		WaitForPotion,
		PreFailed,
		PreFailedBomb,
		RegenLevel
	}
    public class LevelManager : Singleton<LevelManager>
    {
		[Header("map properties")]
		public int maxRows = 8;
		public int maxCols = 7;
		public float squareWidth = 1.2f;
		public float squareHeight = 1.2f;

		[Header("level properties")]
		private int mapLine = 0;
        public int currentLevel;
		public Square[] squaresArray;
		//level data from the file
		public SquareBlocks[] levelSquaresFile = new SquareBlocks[81];
		public Vector2 firstSquarePosition;
		public Transform ParentSquareGame;
		[Header("object prefabs")]
		public GameObject squarePrefab;
		private GameState gameStatus;
		private GameState GameStatus{
			get{
				return gameStatus;
			}
			set{
				gameStatus = value;
				if(value == GameState.WaitForPopup){
					InitLevel();
				}
			}
		}

        public void LoadLevel(){
            currentLevel = PlayerPrefs.GetInt("OpenLevel");// TargetHolder.level;
            if (currentLevel == 0){
                currentLevel = 1;
            }
            LoadDataFromLocal(currentLevel);
        }
        public void LoadDataFromLocal(int currentLevel)
        {
            //Read data from text file
            TextAsset mapText = Resources.Load("Levels/" + currentLevel) as TextAsset;
            if (mapText == null)
            {
                mapText = Resources.Load("Levels/" + currentLevel) as TextAsset;
            }
            ProcessGameDataFromString(mapText.text);
        }
        void ProcessGameDataFromString(string mapText)
        {
			mapLine = 0;
            string[] lines = mapText.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
	
            foreach (string line in lines)
            {
            		if (line.StartsWith("MODE"))
            		{
            			
            		}
            		else if (line.StartsWith("SIZE "))
            		{
						string blocksString = line.Replace("SIZE", string.Empty).Trim();
						string[] sizes = blocksString.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
						maxCols = int.Parse(sizes[0]);
						maxRows = int.Parse(sizes[1]);
						squaresArray = new Square[maxCols * maxRows];
						levelSquaresFile = new SquareBlocks[maxRows * maxCols];
						for (int i = 0; i < levelSquaresFile.Length; i++)
						{

							SquareBlocks sqBlocks = new SquareBlocks();
							sqBlocks.block = SquareTypes.EMPTY;
							sqBlocks.obstacle = SquareTypes.NONE;

							levelSquaresFile[i] = sqBlocks;
						}
					}
            		else if (line.StartsWith("LIMIT"))
            		{
            			
            		}
            		else if (line.StartsWith("COLOR LIMIT "))
            		{
            			
            		}

            		//check third line to get missions
            		else if (line.StartsWith("STARS"))
            		{
            			
            		}
            		else if (line.StartsWith("COLLECT COUNT "))
            		{
            			
            		}
            		else if (line.StartsWith("COLLECT ITEMS "))
            		{
            			
            		}
            		else if (line.StartsWith("CAGE "))
            		{
            			
            		}
            		else if (line.StartsWith("BOMBS "))
            		{
            			
            		}
            		else if (line.StartsWith("GETSTARS "))
            		{
            			
            		}
            		else
            		{ //Maps
                        string[] st = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < st.Length; i++)
                        {
                            levelSquaresFile[mapLine * maxCols + i].block = (SquareTypes)int.Parse(st[i][0].ToString());
							levelSquaresFile[mapLine * maxCols + i].obstacle = (SquareTypes)int.Parse(st[i][1].ToString());
							Debug.Log(st[i][0].ToString()+"==="+st[i][1].ToString());
                        }
						mapLine++;
            		}
            }

			//test
			GameStatus = GameState.WaitForPopup;

        }

		void PrePareGame(){
			squaresArray = new Square[maxCols * maxRows];
		}

		void InitLevel(){
			GenerateLevel();
		}

		private void GenerateLevel(){
			Debug.Log("Tao Map");
			bool chessColor = false;
			float sqWidth = 1.6f;
			float halfSquare = sqWidth / 2;
			Vector3 fieldPos = new Vector3(-maxCols * sqWidth / 2 + halfSquare, maxRows / 1.4f, -10);
			for (int row = 0; row < maxRows; row++)
			{
				if (maxCols % 2 == 0)
					chessColor = !chessColor;
				for (int col = 0; col < maxCols; col++)
				{
					CreateSquare(col, row, chessColor);
					chessColor = !chessColor;
				}

			}
		}

		void CreateSquare(int col, int row, bool chessColor = false){
			GameObject square = null;
			square = Instantiate(squarePrefab, firstSquarePosition + new Vector2(col * squareWidth, -row * squareHeight), Quaternion.identity) as GameObject;
			square.transform.SetParent(ParentSquareGame);
			square.transform.localPosition = firstSquarePosition + new Vector2(col * squareWidth, -row * squareHeight);
			squaresArray[row * maxCols + col] = square.GetComponent<Square>();
			square.GetComponent<Square>().row = row;
			square.GetComponent<Square>().col = col;
			square.GetComponent<Square>().type = SquareTypes.EMPTY;
		}
    }

}
