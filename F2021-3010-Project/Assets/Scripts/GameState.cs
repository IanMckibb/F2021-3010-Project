using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public Player player;
    public int points;

    // Start is called before the first frame update
    void Start()
    {
        this.points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.points += 1;
    }
}
