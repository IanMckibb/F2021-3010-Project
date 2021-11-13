using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int xSize = 20;
    public int ySize = 10;
    public Tile tileObj;
    public Enemy enemyObj;
    public Player playerObj;

    //procedural generation variables
    private int ecount = 0;
    private int tcount = 0;
    private int offset = 0;

    //update variables
    private bool doneGen = false;

    //map handling
    private Tile[,] mapA;
    private Tile[,] mapB;
    private Tile[,] mapC;
    int turn = 0;

    // Start is called before the first frame update
    void Start()
    {
      //generate tiles to block back of first car, eventually this could be a locomotive or caboose
      Tile a = Instantiate(tileObj, new Vector2(-1, 3), Quaternion.identity);
      a.tileName = "wall";
      Tile b = Instantiate(tileObj, new Vector2(-1, 4), Quaternion.identity);
      b.tileName = "wall";
      Tile c = Instantiate(tileObj, new Vector2(-1, 5), Quaternion.identity);
      c.tileName = "wall";

      //generate first two cars
      mapC = generateCar();
      offset = xSize + 1;
      mapA = generateCar();
      offset = offset + 21;
      mapB = generateCar();
    }

    // Update is called once per frame
    void Update()
    {
        //if the player is in the last 5 tiles of the car, generate a new car after the next, and delete the previous
        if(playerObj.transform.position.x >= offset - 5 && playerObj.transform.position.x <= offset + 5){
           if(!doneGen){
              offset = offset + xSize + 1;
              switch(turn){
                  case 0:
                     for(int i = 0; i < xSize; i++){
                        for(int j = 0; j < ySize; j++){
                           mapC[i,j].DestroyTile();
                        }
                     }
                     mapC[20, 3].DestroyTile();
                     mapC[20, 4].DestroyTile();
                     mapC[20, 5].DestroyTile();

                     mapC = generateCar();
                     turn = 1;
                     break;
                  case 1:
                     for(int i = 0; i < xSize; i++){
                        for(int j = 0; j < ySize; j++){
                           mapA[i,j].DestroyTile();
                        }
                     }
                     mapA[20, 3].DestroyTile();
                     mapA[20, 4].DestroyTile();
                     mapA[20, 5].DestroyTile();

                     mapA = generateCar();
                     turn = 2;
                     break;
                  case 2:
                     for(int i = 0; i < xSize; i++){
                        for(int j = 0; j < ySize; j++){
                           mapB[i,j].DestroyTile();
                        }
                     }
                     mapB[20, 3].DestroyTile();
                     mapB[20, 4].DestroyTile();
                     mapB[20, 5].DestroyTile();

                     mapB = generateCar();
                     turn = 0;
                     break;
              }
              doneGen = true;
           }
        }
        //reset boolean once in second 5 tiles of the car
        if(playerObj.transform.position.x >= offset - 15 && playerObj.transform.position.x <= offset - 10){
           doneGen = false;
        }
    }


    // Generates an array of tiles for the next car of the train
    Tile[,] generateCar(){
      
      Tile[,] car = new Tile[xSize + 1, ySize];

      //generate a random 'seed' to create the car with (5 numbers 0 to 9 [set as 0-2 for now for map gen testing])
         //seed[0] -> used in car shape
         //seed[1] -> used in enemy count
         //seed[2] -> 
         //seed[3] -> used in trap count
         //seed[4] ->
      int[] seed = new int[5];
      for(int i = 0; i < 5; i++){
         seed[i] = Random.Range(0,3);
      }
      seed[1] = seed[1] + 2; //just adjusting enemy seed so it spawns more, for testing

      //based on various pieces of seed generate:
         //- shape for car walls, eg if seperated into 2 rooms
         //- locations of objects in the room, such as loot or decoration
         //- locations of enemies and traps (ensuring they're not on top of objects)

      //*** GENERATE CAR ***
      Debug.Log("Generating car shape based on: " + seed[0]);
      Debug.Log("Generating enemies based on: " + seed[1]);
      switch(seed[0]){
         case 0: //basic rectangle
            for(int i = 0; i < xSize; i++){
               for(int j = 0; j < ySize; j++){
                  //create tile objects for car Tile array
                  car[i, j] = Instantiate(tileObj, new Vector2(i + offset, j), Quaternion.identity);

                  //fill outer edges with walls
                  if ((i == 0 || i == xSize - 1 || j == 0 || j == ySize - 1) && j != (ySize - 1) / 2) {
                     car[i, j].tileName = "wall";
                  //fill remaining tiles with floor
                  }else{
                     car[i, j].tileName = "floor";
                     //call entity spawn at current location, put here so they can only spawn on floors
                     spawnEntities(i,j, seed);
                  }
               }
            }

            //make hallway between trains
            car[20, 3] = Instantiate(tileObj, new Vector2(20 + offset, 3), Quaternion.identity);
            car[20, 3].tileName = "wall";
            car[20, 4] = Instantiate(tileObj, new Vector2(20 + offset, 4), Quaternion.identity);
            car[20, 4].tileName = "floor";
            car[20, 5] = Instantiate(tileObj, new Vector2(20 + offset, 5), Quaternion.identity);
            car[20, 5].tileName = "wall";

            break;
         
         case 1: //seperated into two rooms at half point
            for(int i = 0; i < xSize; i++){
               for(int j = 0; j < ySize; j++){
                  //create tile objects for car Tile array
                  car[i, j] = Instantiate(tileObj, new Vector2(i + offset, j), Quaternion.identity);
                  
                  //fill outer edges with walls
                  if ((i == 0 || i == xSize - 1 || j == 0 || j == ySize - 1) && j != (ySize - 1) / 2) {
                     car[i, j].tileName = "wall";
                  //fill middle walls, leave gap in middle
                  }else if(i == (xSize - 1) / 2 && j != (ySize - 1) / 2 ){
                     car[i,j].tileName = "wall";
                  //fill remaining tiles with floor
                  }else{
                     car[i, j].tileName = "floor";
                     //call entity spawn at current location, put here so they can only spawn on floors
                     spawnEntities(i,j, seed);
                  }
               }
            }

            //make hallway between trains
            car[20, 3] = Instantiate(tileObj, new Vector2(20 + offset, 3), Quaternion.identity);
            car[20, 3].tileName = "wall";
            car[20, 4] = Instantiate(tileObj, new Vector2(20 + offset, 4), Quaternion.identity);
            car[20, 4].tileName = "floor";
            car[20, 5] = Instantiate(tileObj, new Vector2(20 + offset, 5), Quaternion.identity);
            car[20, 5].tileName = "wall";

            break;

         case 2: //smaller room at beginning
            for(int i = 0; i < xSize; i++){
               for(int j = 0; j < ySize; j++){
                  //create tile objects for car Tile array
                  car[i, j] = Instantiate(tileObj, new Vector2(i + offset, j), Quaternion.identity);
                  
                  //fill outer edges with walls
                  if ((i == 0 || i == xSize - 1 || j == 0 || j == ySize - 1) && j != (ySize - 1) / 2) {
                     car[i, j].tileName = "wall";
                  //fill front/middle walls, leave gap in middle
                  }else if(i == (xSize - 1) / 4 && j != (ySize - 1) / 2 ){
                     car[i,j].tileName = "wall";
                  //fill remaining tiles with floor
                  }else{
                     car[i, j].tileName = "floor";
                     //call entity spawn at current location, put here so they can only spawn on floors
                     spawnEntities(i,j, seed);
                  }
               }
            }

            //make hallway between trains
            car[20, 3] = Instantiate(tileObj, new Vector2(20 + offset, 3), Quaternion.identity);
            car[20, 3].tileName = "wall";
            car[20, 4] = Instantiate(tileObj, new Vector2(20 + offset, 4), Quaternion.identity);
            car[20, 4].tileName = "floor";
            car[20, 5] = Instantiate(tileObj, new Vector2(20 + offset, 5), Quaternion.identity);
            car[20, 5].tileName = "wall";

            break;
      }

      //reset enemy and trap counters
      ecount = 0;
      tcount = 0;

      return car;
    }

   //spawns enemies and traps, called from the map generation function
    void spawnEntities(int i, int j, int[] seed){
       //*** SPAWN ENEMIES ***
      int sr = Random.Range(0, 1001);
      if(ecount < seed[1] + 1 && i > 2 && sr > (1000 - ((i+(seed[1] ^ 2)) ^ 3))){//if not too many enemies, at least 3 from start, third bit increases spawn chance (expon.) further from entrance
         Debug.Log("enemy gen : seed=" + seed[1] + " : sr=" + sr + " : i/x=" + i);
         Instantiate(enemyObj, new Vector2(i + offset, j), Quaternion.identity);
         ecount++;
      }
      //*** SPAWN TRAPS ****
      sr = Random.Range(0, 1001);
      if(tcount < seed[3] + 1 && i > 2 && sr > (1000 - ((i+(seed[3] ^ 2)) ^ 3))){//if not too many traps, at least 3 from start, third bit increases spawn chance (expon.) further from entrance
         Debug.Log("trap gen : seed=" + seed[3] + " : sr=" + sr + " : i/x=" + i + " ** Not yet implemented.");
         //Instantiate(trapObj, new Vector2(i + offset, j), Quaternion.identity);
         tcount++;
      }
    }

    //Proc. Gen Notes:
      // - maybe make train cars pretty long, for less repeated calls to generation
      // -  - could 'load' between cars as levels if long enough, so no 'stitching' together of cars is needed
}
