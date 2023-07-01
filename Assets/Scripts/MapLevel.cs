using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HieuLajj {
    public class MapLevel : MonoBehaviour
    {
        public int Number;
        // Start is called before the first frame update
        private void Update() {
            // Debug.Log("Fff");
        }
        private void OnMouseEnter() {
        }
        private void OnMouseDown() {
            
        }
        private void OnMouseExit() {
            
        }
        private void OnMouseUpAsButton() {
            Debug.Log("Hello");
            LevelsMap.OnLevelSelected(Number);
        }
    }
}
