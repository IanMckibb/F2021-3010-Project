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
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
        //run check distance every 10 frames
        frameCount++;
        if(frameCount == 10){
            checkDistance();
            frameCount = 0;
        }
    }

    public override void OnCollisionEnter2D(Collision2D col)
    {
        //
    }
}
