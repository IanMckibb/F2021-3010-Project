using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Follow : Enemy
{
    private float baseTime = 1.6f;
    private float currTime;
    private float movementDir;
    private string state;
    // Start is called before the first frame update
    override public void Start()
    {
        this.speed = 1.0f;
        this.currTime = Random.Range(0.0f, this.baseTime);
        this.state = "IDLE";
        this.addComponents();
    }

    // Update is called once per frame
    override public void Update()
    {
         // Check if player destroyed
         if (GameObject.Find("Player") == null)
         {
            return;
         }
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
        this.currTime -= Time.deltaTime;
        checkFollow();
        if (this.currTime <= 0) {
            this.currTime = Random.Range(baseTime - 0.5f, baseTime + 0.5f);
            if (this.state == "FOLLOWING") {
                // Do nothing in this part
            }
            else if (this.state == "IDLE") {
                this.state = "MOVING";
                // Determine movement direction
                this.movementDir = Random.Range(0.0f, 2.0f * Mathf.PI);
            } 
            else if (this.state == "MOVING") {
                this.state = "IDLE";
            }
        }

        if (this.state == "IDLE") {
            // Do nothing
        }
        else if (this.state == "MOVING") {
            if (Mathf.Cos(this.movementDir) < 0) {
                if (!GetComponent<SpriteRenderer>().flipX) GetComponent<SpriteRenderer>().flipX = true;
            } else if (Mathf.Cos(this.movementDir) > 0) {
                if (GetComponent<SpriteRenderer>().flipX) GetComponent<SpriteRenderer>().flipX = false;
            }

            this.Move(new Vector2(Mathf.Cos(this.movementDir), Mathf.Sin(this.movementDir)));
        } 
        else if (this.state == "FOLLOWING") {
            this.movementDir = Mathf.Atan((GameObject.FindGameObjectWithTag("Player").transform.position.y - transform.position.y) / (GameObject.FindGameObjectWithTag("Player").transform.position.x - transform.position.x));
            float xComp = Mathf.Cos(this.movementDir);
            float yComp = Mathf.Sin(this.movementDir);
            if (GameObject.FindGameObjectWithTag("Player").transform.position.x < transform.position.x) {
                xComp *= -1;
                yComp *= -1;
            }
            if (xComp < 0) {
                if (!GetComponent<SpriteRenderer>().flipX) GetComponent<SpriteRenderer>().flipX = true;
            } else if (xComp > 0) {
                if (GetComponent<SpriteRenderer>().flipX) GetComponent<SpriteRenderer>().flipX = false;
            }
            this.Move(new Vector2(xComp, yComp));
        }
    }

    public void checkFollow(){
        float distance = Vector2.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position);
        if (distance < 4.0f){
            this.speed = 3.2f;
            this.state = "FOLLOWING";
        } 
        else if (distance < 4.5f){
            this.speed = 4.2f;
            this.state = "FOLLOWING";
        } 
        else if (this.state == "FOLLOWING" && distance > 5.5f) {
            this.speed = 2.2f;
            this.state = "IDLE";
        }
    }
}
