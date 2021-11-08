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
        for(int i = 0; i < xSize; i++) {
            for(int q = 0; q < ySize; q++) {
                map[i, q] = Instantiate(tileObj, new Vector2(i, q), Quaternion.identity);
                // TESTING
                if (i == 0 || i == xSize - 1 || q == 0 || q == ySize - 1) { // Make wall when on edge for testing
                    map[i, q].tileName = "wall";
                }  else {
                    map[i, q].tileName = "floor";
                }
                // TESTING END
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
