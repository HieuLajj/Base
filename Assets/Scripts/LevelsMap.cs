using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace HieuLajj{
    public class LevelsMap : Singleton<LevelsMap>
    {
        public static event EventHandler<LevelReachedEventArgs> LevelSelected;
        internal static void OnLevelSelected(int number){
            LevelSelected(Instance, new LevelReachedEventArgs (number));
        }
    }
}

