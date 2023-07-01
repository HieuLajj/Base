using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HieuLajj{
    public class LevelReachedEventArgs : MonoBehaviour
    {
        public int Number{
            get;
            private set;
        }
        
        public LevelReachedEventArgs (int number){
            Number = number;
        }
    }

}