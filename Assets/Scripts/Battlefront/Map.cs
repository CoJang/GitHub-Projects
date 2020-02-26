using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    static public Map instance;
    public MeshRenderer MapSpr;
    public MeshRenderer Fog;
    public GameObject Marker;
    public GameObject Aperture;

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
        Way1D = 15,

        Type_End = 16
    }
    /// <summary> spr [1] = one way down, [3] = two way right-left, 
    /// [2] = three way right, [0] = four way </summary>
    public Sprite[] spr = new Sprite[4];
    
    public struct Block
    {
        public Type type;
        public Vector2 pos;
    }
    List<Block> map = new List<Block>();
    int mapsize = 16;

    GameObject[] Tiles;

    private void Awake()
    {
        Tiles = Resources.LoadAll<GameObject>("Prefabs/MapTile/");
        instance = this;
    }

    private void Start()
    {
        //CreateRandomMap();    
    }

    private void CreateRandomMap()
    {
        int j = 0;
        for (int i = 0; i < mapsize; i++)
        {
            Block temp = new Block
            {
                type = (Type)Random.Range(0, (int)Type.Type_End)
            };

            if (i % 4 == 0) j++;
            temp.pos = new Vector2(i % 4 * 1.2f, j * 1.2f);

            map.Add(temp);
            MatchingTile(temp);
        }
    }

    public void PopMap()
    {
        MapSpr.enabled ^= true;
        Fog.enabled ^= true;
        Marker.SetActive(MapSpr.enabled);
        Aperture.SetActive(MapSpr.enabled);
    }

    float hrz;
    float vrt;
    [SerializeField] private float fSpeed = 0.1f;

    private void Update()
    {
        hrz = Input.GetAxis("Horizontal"); vrt = Input.GetAxis("Vertical");

        Vector3 movVec = new Vector3(-vrt, hrz, 0);
        movVec = movVec.normalized * fSpeed;

        Marker.transform.Translate(movVec);
    }

    public void MatchingTile(Block tile)
    {
        switch(tile.type)
        {
            case Type.Blocked:
                break;
            case Type.Way1D:
                Instantiate(Tiles[1], new Vector3(tile.pos.x, tile.pos.y, 1), new Quaternion(0, 0, 90, 1));
                break;
            case Type.Way1L:
                Instantiate(Tiles[1], new Vector3(tile.pos.x, tile.pos.y, 1), new Quaternion(0, 0, 90, 1));
                break;
            case Type.Way1R:
                Instantiate(Tiles[1], new Vector3(tile.pos.x, tile.pos.y, 1), new Quaternion(0, 0, 0, 1));
                break;
            case Type.Way1U:
                Instantiate(Tiles[1], new Vector3(tile.pos.x, tile.pos.y, 1), new Quaternion(0, 0, 90, 1));
                break;
            case Type.Way2H:
                Instantiate(Tiles[3], new Vector3(tile.pos.x, tile.pos.y, 1), new Quaternion(0, 0, 0, 1));
                break;
            case Type.Way2V:
                Instantiate(Tiles[3], new Vector3(tile.pos.x, tile.pos.y, 1), new Quaternion(0, 0, 0, 1));
                break;
            case Type.Way2LD:
                Instantiate(Tiles[3], new Vector3(tile.pos.x, tile.pos.y, 1), new Quaternion(0, 0, 0, 1));
                break;
            case Type.Way2LU:
                Instantiate(Tiles[3], new Vector3(tile.pos.x, tile.pos.y, 1), new Quaternion(0, 0, 0, 1));
                break;
            case Type.Way2RD:
                Instantiate(Tiles[3], new Vector3(tile.pos.x, tile.pos.y, 1), new Quaternion(0, 0, 0, 1));
                break;
            case Type.Way2RU:
                Instantiate(Tiles[3], new Vector3(tile.pos.x, tile.pos.y, 1), new Quaternion(0, 0, 0, 1));
                break;
            case Type.Way3Down:
                Instantiate(Tiles[2], new Vector3(tile.pos.x, tile.pos.y, 1), new Quaternion(0, 0, 0, 1));
                break;
            case Type.Way3Left:
                Instantiate(Tiles[2], new Vector3(tile.pos.x, tile.pos.y, 1), new Quaternion(0, 0, 0, 1));
                break;
            case Type.Way3Right:
                Instantiate(Tiles[2], new Vector3(tile.pos.x, tile.pos.y, 1), new Quaternion(0, 0, 0, 1));
                break;
            case Type.Way3Up:
                Instantiate(Tiles[2], new Vector3(tile.pos.x, tile.pos.y, 1), new Quaternion(0, 0, 0, 1));
                break;
            case Type.Way4:
                Instantiate(Tiles[0], new Vector3(tile.pos.x, tile.pos.y, 1), new Quaternion(0, 0, 0, 1));
                break;
        }
    }
}
