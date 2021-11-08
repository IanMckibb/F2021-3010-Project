using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int xSize = 10;
    public int ySize = 15;
    public Tile tileObj;
    private Tile[,] map;

    // Start is called before the first frame update
    void Start()
    {
        map = new Tile[xSize, ySize];
        for(int i = 0; i < ySize; i++) {
            for(int q = 0; q < xSize; q++) {
                map[i, q] = Instantiate(tileObj, new Vector2(q, i), Quaternion.identity);
                map[i, q].tileName = "floor";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
