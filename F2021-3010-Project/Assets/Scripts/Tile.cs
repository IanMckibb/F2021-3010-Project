using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public string tileName = "";
    public Sprite[] wallSprites = new Sprite[] {};
    public Sprite[] floorSprites = new Sprite[] {};
    public Sprite defaultSprite;
    private SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (tileName == "") {
            print("TIle name is not set");
        }
        createTile();
    }

    public void createTile() {
        switch (tileName) {
            case "wall":
                spriteRenderer.sprite = wallSprites[Random.Range(0, wallSprites.Length)];
                
                // Set boxcollider
                gameObject.AddComponent<BoxCollider2D>();

                // Set rb
                Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
                rb.bodyType = RigidbodyType2D.Static;
                rb.freezeRotation = true;
                break;
            case "floor":
                spriteRenderer.sprite = floorSprites[Random.Range(0, floorSprites.Length)];
                break;
            default:
                spriteRenderer.sprite = defaultSprite;
                break;
        }
        return;
    }

    public void DestroyTile() {
        switch (tileName) {
            case "wall":
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(GetComponent<BoxCollider2D>());
                Destroy(GetComponent<SpriteRenderer>());
                Destroy(this);
                break;
            case "floor":
                Destroy(GetComponent<SpriteRenderer>());
                Destroy(this);
                break;
            default:
                Debug.Log("Tile to be destroyed had invalid or no name.");
                break;
        }
    }

    void Update() {}
}
