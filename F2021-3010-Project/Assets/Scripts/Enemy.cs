using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public float hp = 100.0f;

    // public float speed; Speed already defined in Entity class

    private int frameCount = 0;

    // Update is called once per frame

    public override void Start()
    {
        this.addComponents();
    }
    
    public override void Update()
    {
        //run check distance every 10 frames
        frameCount++;
        if(frameCount == 10){
            checkDistance();
            frameCount = 0;
        }
    }

    public override void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player") {
            hp -= 10.0f;
        }
        print("Enemy lost hp, " + hp.ToString() + " left");
        if (hp <= 0.0f) {
            DestroyEntity();
        }
    }
}
