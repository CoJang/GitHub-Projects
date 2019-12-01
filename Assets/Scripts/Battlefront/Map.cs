using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public enum Type
    {
        Blocked = 0,
        Way4 = 1,       // +

        Way3Right = 2,  // ㅏ
        Way3Left = 3,   // ㅓ
        Way3Up = 4,     // ㅗ
        Way3Down = 5,   // ㅜ

        Way2RU = 6,     // └
        Way2RD = 7,     // ┌
        Way2LU = 8,     // ┘
        Way2LD = 9,     // ┐
        Way2V = 10,     // ㅡ
        Way2H = 11,     // ㅣ

        Way1R = 12,     // Blocked Right
        Way1L = 13, 
        Way1U = 14,
        Way1D = 15
    }

    public Type BlockType;
    
    struct Block
    {
        public Type type;
        public Vector2Int pos;
    }
    List<Block> map = new List<Block>();
    int mapsize = 16;

    private void Start()
    {
        for(int i = 0; i < mapsize; i++)
        {
            Block temp = new Block();
            temp.type = Type.Way4;
        }
    }
}
