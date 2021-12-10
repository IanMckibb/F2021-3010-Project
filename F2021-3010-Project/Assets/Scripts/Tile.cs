using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public string tileName = "";
    public Sprite[] wallSprites = new Sprite[] {};
    public Sprite[] floorSprites = new Sprite[] {};
    public Sprite[] btwnEndSprites = new Sprite[] {};
    public Sprite[] btwnWallSprites = new Sprite[] {};
    public Sprite[] btwnFloorSprites = new Sprite[] {};
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
                spriteRenderer.sprite = wallSprites[Random.Range(0, 2)];
                
                // Set boxcollider
                gameObject.AddComponent<BoxCollider2D>();

                // Set rb
                Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
                rb.bodyType = RigidbodyType2D.Static;
                rb.freezeRotation = true;
                break;

            case "box":
                spriteRenderer.sprite = wallSprites[2];
                
                // Set boxcollider
                gameObject.AddComponent<BoxCollider2D>();

                // Set rb
                Rigidbody2D rb7 = gameObject.AddComponent<Rigidbody2D>();
                rb7.bodyType = RigidbodyType2D.Static;
                rb7.freezeRotation = true;
                break;

            case "floor":
                spriteRenderer.sprite = floorSprites[0];
                break;

            case "wheel":
                spriteRenderer.sprite = floorSprites[1];
                break;

            case "btwnend_L":
                spriteRenderer.sprite = btwnEndSprites[0];
                
                // Set boxcollider
                gameObject.AddComponent<BoxCollider2D>();

                // Set rb
                Rigidbody2D rb2 = gameObject.AddComponent<Rigidbody2D>();
                rb2.bodyType = RigidbodyType2D.Static;
                rb2.freezeRotation = true;
                break;

            case "btwnend_R":
                spriteRenderer.sprite = btwnEndSprites[1];
                
                // Set boxcollider
                gameObject.AddComponent<BoxCollider2D>();

                // Set rb
                Rigidbody2D rb4 = gameObject.AddComponent<Rigidbody2D>();
                rb4.bodyType = RigidbodyType2D.Static;
                rb4.freezeRotation = true;
                break;

            case "btwnwall_L_T":
                spriteRenderer.sprite = btwnWallSprites[0];
                
                // Set boxcollider
                gameObject.AddComponent<BoxCollider2D>();

                // Set rb
                Rigidbody2D rb3 = gameObject.AddComponent<Rigidbody2D>();
                rb3.bodyType = RigidbodyType2D.Static;
                rb3.freezeRotation = true;
                break;
            case "btwnwall_R_T":
                spriteRenderer.sprite = btwnWallSprites[1];
                
                // Set boxcollider
                gameObject.AddComponent<BoxCollider2D>();

                // Set rb
                Rigidbody2D rb6 = gameObject.AddComponent<Rigidbody2D>();
                rb6.bodyType = RigidbodyType2D.Static;
                rb6.freezeRotation = true;
                break;

            case "btwnwall_L_B":
                spriteRenderer.sprite = btwnWallSprites[2];
                
                // Set boxcollider
                gameObject.AddComponent<BoxCollider2D>();

                // Set rb
                Rigidbody2D rb8 = gameObject.AddComponent<Rigidbody2D>();
                rb8.bodyType = RigidbodyType2D.Static;
                rb8.freezeRotation = true;
                break;
            case "btwnwall_R_B":
                spriteRenderer.sprite = btwnWallSprites[3];
                
                // Set boxcollider
                gameObject.AddComponent<BoxCollider2D>();

                // Set rb
                Rigidbody2D rb9 = gameObject.AddComponent<Rigidbody2D>();
                rb9.bodyType = RigidbodyType2D.Static;
                rb9.freezeRotation = true;
                break;
            
            case "btwnwall_W_L_T":
                spriteRenderer.sprite = btwnWallSprites[4];
                
                // Set boxcollider
                gameObject.AddComponent<BoxCollider2D>();

                // Set rb
                Rigidbody2D rb0 = gameObject.AddComponent<Rigidbody2D>();
                rb0.bodyType = RigidbodyType2D.Static;
                rb0.freezeRotation = true;
                break;
            case "btwnwall_W_L_B":
                spriteRenderer.sprite = btwnWallSprites[6];
                
                // Set boxcollider
                gameObject.AddComponent<BoxCollider2D>();

                // Set rb
                Rigidbody2D rb0a = gameObject.AddComponent<Rigidbody2D>();
                rb0a.bodyType = RigidbodyType2D.Static;
                rb0a.freezeRotation = true;
                break;
            case "btwnwall_W_R_T":
                spriteRenderer.sprite = btwnWallSprites[5];
                
                // Set boxcollider
                gameObject.AddComponent<BoxCollider2D>();

                // Set rb
                Rigidbody2D rb1 = gameObject.AddComponent<Rigidbody2D>();
                rb1.bodyType = RigidbodyType2D.Static;
                rb1.freezeRotation = true;
                break;
            case "btwnwall_W_R_B":
                spriteRenderer.sprite = btwnWallSprites[7];
                
                // Set boxcollider
                gameObject.AddComponent<BoxCollider2D>();

                // Set rb
                Rigidbody2D rb1a = gameObject.AddComponent<Rigidbody2D>();
                rb1a.bodyType = RigidbodyType2D.Static;
                rb1a.freezeRotation = true;
                break;

            case "btwnfloor_L":
                spriteRenderer.sprite = btwnFloorSprites[0];
                break;

            case "btwnfloor_R":
                spriteRenderer.sprite = btwnFloorSprites[1];
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
            case "box":
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(GetComponent<BoxCollider2D>());
                Destroy(GetComponent<SpriteRenderer>());
                Destroy(this);
                break;
            case "floor":
                Destroy(GetComponent<SpriteRenderer>());
                Destroy(this);
                break;
            case "btwnend_L":
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(GetComponent<BoxCollider2D>());
                Destroy(GetComponent<SpriteRenderer>());
                Destroy(this);
                break;
            case "btwnend_R":
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(GetComponent<BoxCollider2D>());
                Destroy(GetComponent<SpriteRenderer>());
                Destroy(this);
                break;
            case "btwnwall_L_T":
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(GetComponent<BoxCollider2D>());
                Destroy(GetComponent<SpriteRenderer>());
                Destroy(this);
                break;
            case "btwnwall_L_B":
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(GetComponent<BoxCollider2D>());
                Destroy(GetComponent<SpriteRenderer>());
                Destroy(this);
                break;
            case "btwnwall_R_T":
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(GetComponent<BoxCollider2D>());
                Destroy(GetComponent<SpriteRenderer>());
                Destroy(this);
                break;
            case "btwnwall_R_B":
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(GetComponent<BoxCollider2D>());
                Destroy(GetComponent<SpriteRenderer>());
                Destroy(this);
                break;
            case "btwnwall_W_R_T":
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(GetComponent<BoxCollider2D>());
                Destroy(GetComponent<SpriteRenderer>());
                Destroy(this);
                break;
            case "btwnwall_W_R_B":
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(GetComponent<BoxCollider2D>());
                Destroy(GetComponent<SpriteRenderer>());
                Destroy(this);
                break;
            case "btwnfloor_L":
                Destroy(GetComponent<SpriteRenderer>());
                Destroy(this);
                break;
            case "btwnfloor_R":
                Destroy(GetComponent<SpriteRenderer>());
                Destroy(this);
                break;
            default:
                Debug.Log("Tile to be destroyed had invalid or no name.");
                break;
        }
    }

    void Update() {
        if (tileName == "wall" || tileName == "box") {
            GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
            GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        }
    }
}
