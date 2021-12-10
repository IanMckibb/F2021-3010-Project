using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public Player player;
    public float maxPos;
    public long points;

    // Start is called before the first frame update
    void Start()
    {
        this.maxPos = 0.0f;
        this.points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Update points to player x position
        if (player.transform.position.x > maxPos) {
            maxPos = player.transform.position.x;
        }
        this.points = (long)Mathf.Floor(maxPos * 100.0f);
    }
}
