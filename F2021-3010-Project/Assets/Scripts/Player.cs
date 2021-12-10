using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    public float maxHp = 100.0f;
    public float hp = 100.0f;
    public GameState gs;

    public GameObject resetText;
    public GameObject menuText;
    public GameObject resetPanel;
    

    // Update is called once per frame
    public override void Update()
    {
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;

        // Movement translation vector
        Vector2 translation = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Move
        if (translation.x < 0) {
            if (!GetComponent<SpriteRenderer>().flipX) GetComponent<SpriteRenderer>().flipX = true;
        } else if (translation.x > 0) {
            if (GetComponent<SpriteRenderer>().flipX) GetComponent<SpriteRenderer>().flipX = false;
        }
        Move(translation);

        // Check if no HP, if so game ends.
        if (this.hp <= -100.0f) {
            // Set game over
            print("Destroyed " + this.hp.ToString());

            resetText.gameObject.SetActive(true);
            menuText.gameObject.SetActive(true);
            resetPanel.gameObject.SetActive(true);
            resetText.GetComponent<TMPro.TextMeshProUGUI>().text = "Your Score: " + gs.points.ToString();
            DestroyEntity();
        }
    }

    public void OnCollisionStay2D(Collision2D col) {
            print(col.gameObject.name);
        if (col.gameObject.name == "Enemy(Clone)") {
            hp -= 0.3f;
        }
    }

    public override void OnCollisionEnter2D(Collision2D col)
    {
        //
    }

    public void OnCollisionExit(Collision col)
    {
        //
    }
}
