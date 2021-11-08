using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public float hp = 100.0f;

    public float angle;
    public float angleChange = 0.0f;
    private float angleChangeRange = 0.05f;

    // public float speed; Speed already defined in Entity class
    public float speedChange = 0.0f;
    private float speedChangeRange = 1f;

    // Update is called once per frame

    public override void Start()
    {
        this.addComponents();

        this.angle = Random.Range(0, 2 * Mathf.PI);
        this.speed = Random.Range(1, 2);
    }
    
    public override void Update()
    {
        angleChange += Random.Range(-angleChangeRange, angleChangeRange) * Time.deltaTime;
        angle += angleChange;

        speedChange = Random.Range(-speedChangeRange, speedChangeRange) * Time.deltaTime;
        speed += speedChange;

        Move(new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)));
    }

    public override void OnCollisionEnter2D(Collision2D col)
    {
        hp -= 10.0f;
        print("Enemy lost hp, " + hp.ToString() + " left");
        if (hp <= 0.0f) {
            DestroyEntity();
        }
    }
}
