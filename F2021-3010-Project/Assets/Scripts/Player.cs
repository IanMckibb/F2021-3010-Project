using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public float hp = 100.0f;
    public GameState gs;

    // Update is called once per frame
    public override void Update()
    {
        // Movement translation vector
        Vector2 translation = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // Move
        Move(translation);
    }

    public override void OnCollisionEnter2D(Collision2D col)
    {
        //
    }
}
