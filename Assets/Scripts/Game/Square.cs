using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HieuLajj{
    public enum SquareTypes{
    NONE = 0,
    EMPTY,
    BLOCK,
    WIREBLOCK
    }

    public class Square : MonoBehaviour
    {
        public Square square;
        public int row;
        public int col;
        public SquareTypes type;
    }

}