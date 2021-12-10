using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Vector2 position;
    public float size = 1.0f;
    public float speed = 5.0f;
    private Sprite sprite;

    private Rigidbody2D rb;
    private BoxCollider2D bc;

    private int fcount = 0;

    // Start is called before the first frame update
    public virtual void Start()
    {
        this.addComponents();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //run check distance every 10 frames
        fcount++;
        if(fcount == 10) {
            checkDistance();
            fcount = 0;
        }
    }

    //check if entity is too far from player, and destroy if so
    public void checkDistance(){
        float distance = GameObject.FindGameObjectWithTag("Player").transform.position.x - transform.position.x;
        if(distance > 30) {
            DestroyEntity();
        }
    }

    public void addComponents() {
        // Set boxcollider
        this.bc = gameObject.AddComponent<BoxCollider2D>();
        bc.size = new Vector3(0.5f, 0.5f, 0.5f);

        // Set rb
        this.rb = gameObject.AddComponent<Rigidbody2D>();
        this.rb.bodyType = RigidbodyType2D.Dynamic;
        this.rb.freezeRotation = true;
    }

    public void DestroyEntity() {
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(GetComponent<SpriteRenderer>());
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Destroy(this);

            //** need to add case where entity is destroyed if too far from player, as it is hard to handle with map gen
    }

    public void Move(Vector2 translation) {
        transform.Translate(translation * Time.deltaTime * speed);
    }

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        //print("OnCollisionEnter2D");
    }
}
