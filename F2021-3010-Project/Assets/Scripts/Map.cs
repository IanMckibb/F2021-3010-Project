using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private int xSize = 28;
    private int ySize = 11;
    public Tile tileObj;
    public Enemy enemyObj;
    public Player playerObj;

    //procedural generation variables
    private int ecount = 0;
    //private int tcount = 0;
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
      //generate tiles to block back of first car, this could be a locomotive or caboose for someone with art skills
      for(int i = 2; i < ySize - 2; i++){
         if(i >= 3 && i <= ySize - 4){
            Tile a = Instantiate(tileObj, new Vector2(-1, i), Quaternion.identity);
            a.tileName = "box";
         }else if(i >= ySize/2){
            Tile a = Instantiate(tileObj, new Vector2(-1, i), Quaternion.identity);
            a.tileName = "btwnwall_W_L_T";
         }else{
            Tile a = Instantiate(tileObj, new Vector2(-1, i), Quaternion.identity);
            a.tileName = "btwnwall_W_L_B";
         }
      }

      //generate first two cars
      mapC = generateCar();
      offset = xSize;
      mapA = generateCar();
      offset = offset + xSize;
      mapB = generateCar();
    }

    // Update is called once per frame
    void Update()
    {
         // Check if player destroyed
         if (GameObject.Find("Player") == null)
         {
            return;
         }

        //if the player is in the last 5 tiles of the car, generate a new car after the next, and delete the previous
        if(playerObj.transform.position.x >= offset - 5 && playerObj.transform.position.x <= offset + 5){
           if(!doneGen){
              offset = offset + xSize;
              switch(turn){
                  case 0:
                     for(int i = 0; i < xSize; i++){
                        for(int j = 0; j < ySize; j++){
                           mapC[i,j].DestroyTile();
                        }
                     }
                     mapC = generateCar();
                     turn = 1;
                     break;

                  case 1:
                     for(int i = 0; i < xSize; i++){
                        for(int j = 0; j < ySize; j++){
                           mapA[i,j].DestroyTile();
                        }
                     }
                     mapA = generateCar();
                     turn = 2;
                     break;

                  case 2:
                     for(int i = 0; i < xSize; i++){
                        for(int j = 0; j < ySize; j++){
                           mapB[i,j].DestroyTile();
                        }
                     }

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
      
      Tile[,] car = new Tile[xSize, ySize];

      //generate a random 'seed' to create the car with
         //seed[0] -> used in car shape
         //seed[1] -> used in enemy count
         //seed[2] -> used in box spawning
      int[] seed = new int[3];
      for(int i = 0; i < 3; i++){
         seed[i] = Random.Range(0,3);
      }
      seed[1] = seed[1] + 4; //just adjusting enemy seed so it spawns more

      //based on various pieces of seed generate:
         //- shape for car walls, eg if seperated into 2 rooms
         //- locations of objects in the room, such as loot or decoration
         //- locations of enemies and traps (ensuring they're not on top of objects)

      //*** GENERATE CAR ***
      Debug.Log("Generating car shape based on: " + seed[0]);
      Debug.Log("Generating enemies based on: " + seed[1]);

      //seed[0] = 1;

      switch(seed[0]){
         case 0: //empty car
            for(int i = 0; i < xSize; i++){
               for(int j = 0; j < ySize; j++){
                  //create tile objects for car Tile array
                  car[i, j] = Instantiate(tileObj, new Vector2(i + offset, j), Quaternion.identity);

                  //fill outer edges with walls
                  if ((j == 0 || j == ySize - 1) && (i != 0 || i != ySize - 1)) {
                     car[i, j].tileName = "wall";
                  
                  //btwn walls and floors
                  //}else if((i == 0 && (j < (ySize/2)-2 || j > (ySize/2)+2))){
                  //   car[i,j].tileName = "btwnwall_R";
                  //}else if(i == xSize-1 && (j < (ySize/2)-2 || j > (ySize/2)+2)){
                  //    car[i,j].tileName = "btwnwall_L";
                  }else if(i == 0){
                      car[i,j].tileName = "btwnfloor_R";
                  }else if(i == xSize - 1){
                     car[i,j].tileName = "btwnfloor_L";
                  
                  //fill remaining tiles with floor
                  }else{
                     car[i, j].tileName = "floor";
                     //call entity spawn at current location, put here so they can only spawn on floors
                     spawnEntities(i,j, seed);
                  }
               }
            }
            //btwn car ends
            car[0,0].tileName = "btwnend_R";
            car[0,ySize - 1].tileName = "btwnend_R";
            car[xSize - 1,0].tileName = "btwnend_L";
            car[xSize - 1,ySize - 1].tileName = "btwnend_L";

            //btwn car walls
            car[0,1].tileName = "btwnwall_R_B";
            car[0,2].tileName = "btwnwall_W_R_B";
            car[0,ySize - 2].tileName = "btwnwall_R_T";
            car[0,ySize - 3].tileName = "btwnwall_W_R_T";
            car[xSize - 1,1].tileName = "btwnwall_L_B";
            car[xSize - 1,2].tileName = "btwnwall_W_L_B";
            car[xSize - 1,ySize - 2].tileName = "btwnwall_L_T";
            car[xSize - 1,ySize - 3].tileName = "btwnwall_W_L_T";
            break;
         
         case 1: //box walls
            for(int i = 0; i < xSize; i++){
               for(int j = 0; j < ySize; j++){
                  //create tile objects for car Tile array
                  car[i, j] = Instantiate(tileObj, new Vector2(i + offset, j), Quaternion.identity);

                  //fill outer edges with walls
                  if ((j == 0 || j == ySize - 1) && (i != 0 || i != ySize - 1)) {
                     car[i, j].tileName = "wall";
                  
                  //btwn walls and floors
                  }else if((i == 0 && (j < (ySize/2)-2 || j > (ySize/2)+2))){
                     car[i,j].tileName = "btwnwall_R";
                  }else if(i == xSize-1 && (j < (ySize/2)-2 || j > (ySize/2)+2)){
                     car[i,j].tileName = "btwnwall_L";
                  }else if(i == 0){
                     car[i,j].tileName = "btwnfloor_R";
                  }else if(i == xSize - 1){
                     car[i,j].tileName = "btwnfloor_L";
                  
                  //fill remaining tiles with floor
                  }else{
                     car[i, j].tileName = "floor";
                     //call entity spawn at current location, put here so they can only spawn on floors
                     spawnEntities(i,j, seed);
                  }
               }
            }
            //btwn car ends
            car[0,0].tileName = "btwnend_R";
            car[0,ySize - 1].tileName = "btwnend_R";
            car[xSize - 1,0].tileName = "btwnend_L";
            car[xSize - 1,ySize - 1].tileName = "btwnend_L";

            //btwn car walls
            car[0,1].tileName = "btwnwall_R_B";
            car[0,2].tileName = "btwnwall_W_R_B";
            car[0,ySize - 2].tileName = "btwnwall_R_T";
            car[0,ySize - 3].tileName = "btwnwall_W_R_T";
            car[xSize - 1,1].tileName = "btwnwall_L_B";
            car[xSize - 1,2].tileName = "btwnwall_W_L_B";
            car[xSize - 1,ySize - 2].tileName = "btwnwall_L_T";
            car[xSize - 1,ySize - 3].tileName = "btwnwall_W_L_T";

            //box walls
            for(int i = 1; i < ySize - 1; i++){
               if(i < (ySize/2)-1 || i > (ySize/2)+1){
                  car[((xSize/2)-5 + (seed[2]*3)), i].tileName = "box";
               }
            }
            break;
         case 2: //random boxes
            for(int i = 0; i < xSize; i++){
               for(int j = 0; j < ySize; j++){
                  //create tile objects for car Tile array
                  car[i, j] = Instantiate(tileObj, new Vector2(i + offset, j), Quaternion.identity);

                  //fill outer edges with walls
                  if ((j == 0 || j == ySize - 1) && (i != 0 || i != ySize - 1)) {
                     car[i, j].tileName = "wall";
                  
                  //btwn walls and floors
                  }else if((i == 0 && (j < (ySize/2)-2 || j > (ySize/2)+2))){
                     car[i,j].tileName = "btwnwall_R";
                  }else if(i == xSize-1 && (j < (ySize/2)-2 || j > (ySize/2)+2)){
                     car[i,j].tileName = "btwnwall_L";
                  }else if(i == 0){
                     car[i,j].tileName = "btwnfloor_R";
                  }else if(i == xSize - 1){
                     car[i,j].tileName = "btwnfloor_L";
                  
                  //fill remaining tiles with floor
                  }else{
                     car[i, j].tileName = "floor";
                     //call entity spawn at current location, put here so they can only spawn on floors
                     spawnEntities(i,j, seed);
                  }
               }
            }
            //btwn car 
            car[0,0].tileName = "btwnend_R";
            car[0,ySize - 1].tileName = "btwnend_R";
            car[xSize - 1,0].tileName = "btwnend_L";
            car[xSize - 1,ySize - 1].tileName = "btwnend_L";

            //btwn car walls
            car[0,1].tileName = "btwnwall_R_B";
            car[0,2].tileName = "btwnwall_W_R_B";
            car[0,ySize - 2].tileName = "btwnwall_R_T";
            car[0,ySize - 3].tileName = "btwnwall_W_R_T";
            car[xSize - 1,1].tileName = "btwnwall_L_B";
            car[xSize - 1,2].tileName = "btwnwall_W_L_B";
            car[xSize - 1,ySize - 2].tileName = "btwnwall_L_T";
            car[xSize - 1,ySize - 3].tileName = "btwnwall_W_L_T";

            //randomly place boxes
            int r = Random.Range(5,12);
            for(int z = 0; z < r; z++){
               int x = Random.Range(3, xSize - 2);
               int y = Random.Range(2, ySize - 1);
               car[x,y].tileName = "box";
            }
            break;
      }

      //reset enemy and trap counters
      ecount = 0;
      //tcount = 0;

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
      // sr = Random.Range(0, 1001);
      // if(tcount < seed[3] + 1 && i > 2 && sr > (1000 - ((i+(seed[3] ^ 2)) ^ 3))){//if not too many traps, at least 3 from start, third bit increases spawn chance (expon.) further from entrance
      //    Debug.Log("trap gen : seed=" + seed[3] + " : sr=" + sr + " : i/x=" + i + " ** Not yet implemented.");
      //    //Instantiate(trapObj, new Vector2(i + offset, j), Quaternion.identity);
      //    tcount++;
      // }
    }
}
