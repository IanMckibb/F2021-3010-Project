using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_A : Enemy
{
    private float baseTime = 2.0f;
    private float currTime;
    private float movementDir;
    private string state;
    // Start is called before the first frame update
    override public void Start()
    {
        this.speed = 1.0f;
        this.currTime = this.baseTime;
        this.state = "IDLE";
        this.addComponents();
    }

    // Update is called once per frame
    override public void Update()
    {
        currTime -= Time.deltaTime;
        if (currTime <= 0) {
            currTime = baseTime;
            checkFollow();
            if (this.state == "FOLLOWING") {
                // Do nothing in this part
            }
            else if (this.state == "IDLE") {
                this.state = "MOVING";
                // Determine movement direction
                movementDir = Random.Range(0.0f, 2.0f * Mathf.PI);
            } 
            else if (this.state == "MOVING") {
                this.state = "IDLE";
            }
        }

        if (this.state == "IDLE") {
            // Do nothing
        }
        else if (this.state == "MOVING") {
            this.Move(new Vector2(Mathf.Cos(this.movementDir), Mathf.Sin(this.movementDir)));
        } 
        else if (this.state == "FOLLOWING") {
            movementDir = Mathf.Atan(GameObject.FindGameObjectWithTag("Player").transform.position.y - transform.position.y / GameObject.FindGameObjectWithTag("Player").transform.position.y - transform.position.y);
            print(movementDir);
            float xComp = Mathf.Cos(this.movementDir);
            if (GameObject.FindGameObjectWithTag("Player").transform.position.x < transform.position.x) {
                xComp = -1;
            }
            this.Move(new Vector2(xComp, Mathf.Sin(this.movementDir)));
        }
    }

    public void checkFollow(){
        float distance = Vector2.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position);
        if (distance < 3.0f){
            this.speed = 1.2f;
            this.state = "FOLLOWING";
        } 
        else if (distance > 4.5f) {
            this.speed = 1.0f;
            this.state = "IDLE";
        }
    }
}
