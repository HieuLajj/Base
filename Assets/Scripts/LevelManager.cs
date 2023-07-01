using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HieuLajj{
    public class LevelManager : Singleton<LevelManager>
    {
        public int currentLevel;
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
            string[] lines = mapText.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
	
            foreach (string line in lines)
            {
            		if (line.StartsWith("MODE"))
            		{
            			
            		}
            		else if (line.StartsWith("SIZE "))
            		{
            		
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
                            Debug.Log(st[i]);
                        }
            		}
            	}

        }
    }

}
