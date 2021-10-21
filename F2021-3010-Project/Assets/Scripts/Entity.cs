using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Vector2 position;
    public float size = 1.0f;
    private const float speed = 5.0f;
    private Sprite sprite;

    private Rigidbody2D rb;
    private BoxCollider2D bc;

    // Start is called before the first frame update
    public virtual void Start()
    {
        // Set boxcollider
        this.bc = gameObject.AddComponent<BoxCollider2D>();

        // Set rb
        this.rb = gameObject.AddComponent<Rigidbody2D>();
        this.rb.bodyType = RigidbodyType2D.Dynamic;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public void Move(Vector2 translation) {
        transform.Translate(translation * Time.deltaTime * speed);
    }

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        print("OnCollisionEnter2D");
    }
}