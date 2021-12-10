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

      Tile a1 = Instantiate(tileObj, new Vector2(2 + offset, -1), Quaternion.identity);
      a1.tileName = "wheel";
      Tile a2 = Instantiate(tileObj, new Vector2(3 + offset, -1), Quaternion.identity);
      a2.tileName = "wheel";
      Tile a3 = Instantiate(tileObj, new Vector2(4 + offset, -1), Quaternion.identity);
      a3.tileName = "wheel";
      Tile a4 = Instantiate(tileObj, new Vector2(5 + offset, -1), Quaternion.identity);
      a4.tileName = "wheel";

      Tile b1 = Instantiate(tileObj, new Vector2(22 + offset, -1), Quaternion.identity);
      b1.tileName = "wheel";
      Tile b2 = Instantiate(tileObj, new Vector2(23 + offset, -1), Quaternion.identity);
      b2.tileName = "wheel";
      Tile b3 = Instantiate(tileObj, new Vector2(24 + offset, -1), Quaternion.identity);
      b3.tileName = "wheel";
      Tile b4 = Instantiate(tileObj, new Vector2(25 + offset, -1), Quaternion.identity);
      b4.tileName = "wheel";

      offset = xSize;
      mapA = generateCar();
      Tile c1 = Instantiate(tileObj, new Vector2(2 + offset, -1), Quaternion.identity);
      c1.tileName = "wheel";
      Tile c2 = Instantiate(tileObj, new Vector2(3 + offset, -1), Quaternion.identity);
      c2.tileName = "wheel";
      Tile c3 = Instantiate(tileObj, new Vector2(4 + offset, -1), Quaternion.identity);
      c3.tileName = "wheel";
      Tile c4 = Instantiate(tileObj, new Vector2(5 + offset, -1), Quaternion.identity);
      c4.tileName = "wheel";

      Tile d1 = Instantiate(tileObj, new Vector2(22 + offset, -1), Quaternion.identity);
      d1.tileName = "wheel";
      Tile d2 = Instantiate(tileObj, new Vector2(23 + offset, -1), Quaternion.identity);
      d2.tileName = "wheel";
      Tile d3 = Instantiate(tileObj, new Vector2(24 + offset, -1), Quaternion.identity);
      d3.tileName = "wheel";
      Tile d4 = Instantiate(tileObj, new Vector2(25 + offset, -1), Quaternion.identity);
      d4.tileName = "wheel";

      offset = offset + xSize;
      mapB = generateCar();

      Tile e1 = Instantiate(tileObj, new Vector2(2 + offset, -1), Quaternion.identity);
      e1.tileName = "wheel";
      Tile e2 = Instantiate(tileObj, new Vector2(3 + offset, -1), Quaternion.identity);
      e2.tileName = "wheel";
      Tile e3 = Instantiate(tileObj, new Vector2(4 + offset, -1), Quaternion.identity);
      e3.tileName = "wheel";
      Tile e4 = Instantiate(tileObj, new Vector2(5 + offset, -1), Quaternion.identity);
      e4.tileName = "wheel";

      Tile f1 = Instantiate(tileObj, new Vector2(22 + offset, -1), Quaternion.identity);
      f1.tileName = "wheel";
      Tile f2 = Instantiate(tileObj, new Vector2(23 + offset, -1), Quaternion.identity);
      f2.tileName = "wheel";
      Tile f3 = Instantiate(tileObj, new Vector2(24 + offset, -1), Quaternion.identity);
      f3.tileName = "wheel";
      Tile f4 = Instantiate(tileObj, new Vector2(25 + offset, -1), Quaternion.identity);
      f4.tileName = "wheel";
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

                     Tile aa1 = Instantiate(tileObj, new Vector2(2 + offset, -1), Quaternion.identity);
                     aa1.tileName = "wheel";
                     Tile aa2 = Instantiate(tileObj, new Vector2(3 + offset, -1), Quaternion.identity);
                     aa2.tileName = "wheel";
                     Tile aa3 = Instantiate(tileObj, new Vector2(4 + offset, -1), Quaternion.identity);
                     aa3.tileName = "wheel";
                     Tile aa4 = Instantiate(tileObj, new Vector2(5 + offset, -1), Quaternion.identity);
                     aa4.tileName = "wheel";

                     Tile ba1 = Instantiate(tileObj, new Vector2(22 + offset, -1), Quaternion.identity);
                     ba1.tileName = "wheel";
                     Tile ba2 = Instantiate(tileObj, new Vector2(23 + offset, -1), Quaternion.identity);
                     ba2.tileName = "wheel";
                     Tile ba3 = Instantiate(tileObj, new Vector2(24 + offset, -1), Quaternion.identity);
                     ba3.tileName = "wheel";
                     Tile ba4 = Instantiate(tileObj, new Vector2(25 + offset, -1), Quaternion.identity);
                     ba4.tileName = "wheel";

                     turn = 1;
                     break;

                  case 1:
                     for(int i = 0; i < xSize; i++){
                        for(int j = 0; j < ySize; j++){
                           mapA[i,j].DestroyTile();
                        }
                     }
                     mapA = generateCar();

                     Tile aaa1 = Instantiate(tileObj, new Vector2(2 + offset, -1), Quaternion.identity);
                     aaa1.tileName = "wheel";
                     Tile aaa2 = Instantiate(tileObj, new Vector2(3 + offset, -1), Quaternion.identity);
                     aaa2.tileName = "wheel";
                     Tile aaa3 = Instantiate(tileObj, new Vector2(4 + offset, -1), Quaternion.identity);
                     aaa3.tileName = "wheel";
                     Tile aaa4 = Instantiate(tileObj, new Vector2(5 + offset, -1), Quaternion.identity);
                     aaa4.tileName = "wheel";

                     Tile baa1 = Instantiate(tileObj, new Vector2(22 + offset, -1), Quaternion.identity);
                     baa1.tileName = "wheel";
                     Tile baa2 = Instantiate(tileObj, new Vector2(23 + offset, -1), Quaternion.identity);
                     baa2.tileName = "wheel";
                     Tile baa3 = Instantiate(tileObj, new Vector2(24 + offset, -1), Quaternion.identity);
                     baa3.tileName = "wheel";
                     Tile baa4 = Instantiate(tileObj, new Vector2(25 + offset, -1), Quaternion.identity);
                     baa4.tileName = "wheel";

                     turn = 2;
                     break;

                  case 2:
                     for(int i = 0; i < xSize; i++){
                        for(int j = 0; j < ySize; j++){
                           mapB[i,j].DestroyTile();
                        }
                     }

                     mapB = generateCar();

                     Tile aaaa1 = Instantiate(tileObj, new Vector2(2 + offset, -1), Quaternion.identity);
                     aaaa1.tileName = "wheel";
                     Tile aaaa2 = Instantiate(tileObj, new Vector2(3 + offset, -1), Quaternion.identity);
                     aaaa2.tileName = "wheel";
                     Tile aaaa3 = Instantiate(tileObj, new Vector2(4 + offset, -1), Quaternion.identity);
                     aaaa3.tileName = "wheel";
                     Tile aaaa4 = Instantiate(tileObj, new Vector2(5 + offset, -1), Quaternion.identity);
                     aaaa4.tileName = "wheel";

                     Tile baaa1 = Instantiate(tileObj, new Vector2(22 + offset, -1), Quaternion.identity);
                     baaa1.tileName = "wheel";
                     Tile baaa2 = Instantiate(tileObj, new Vector2(23 + offset, -1), Quaternion.identity);
                     baaa2.tileName = "wheel";
                     Tile baaa3 = Instantiate(tileObj, new Vector2(24 + offset, -1), Quaternion.identity);
                     baaa3.tileName = "wheel";
                     Tile baaa4 = Instantiate(tileObj, new Vector2(25 + offset, -1), Quaternion.identity);
                     baaa4.tileName = "wheel";

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
      seed[1] = seed[1] + 4 + (offset / 14); //just adjusting enemy seed so it spawns more

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
                  car[((xSize/2)-5 + (seed[2]*2)), i].tileName = "box";
               }
               if(i < (ySize/2)-1 || i > (ySize/2)+1){
                  car[((xSize/2)+5 + (seed[2]*2)), i].tileName = "box";
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
            int r = Random.Range(5,20);
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
      if(ecount < seed[1] * 2 && i > 2 && sr > (1000 - ((i+(seed[1] ^ 2)) ^ 3))){//if not too many enemies, at least 3 from start, third bit increases spawn chance (expon.) further from entrance
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
