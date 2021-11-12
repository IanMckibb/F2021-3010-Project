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

    void Update() {}
}