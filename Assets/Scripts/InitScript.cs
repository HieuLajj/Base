using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HieuLajj{
    public class InitScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            
        }
        private void OnEnable() {
            LevelsMap.LevelSelected += OnLevelClicked;
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void OnLevelClicked(object sender, LevelReachedEventArgs args){
            PlayerPrefs.SetInt("OpenLevel", args.Number);
            LevelManager.Instance.LoadLevel();
        }

        private void OnDisable() {
            LevelsMap.LevelSelected -= OnLevelClicked;
        }
    }

}
