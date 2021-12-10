using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHPBar : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform hpBar;
    public Player player;
    public float unit;
    public float lastHP;
    float delta = 0.0f;
    void Start()
    {
        unit = hpBar.rect.width / player.maxHp;
        lastHP = player.hp;
    }

    // Update is called once per frame
    void Update()
    {
         // Check if player destroyed
         if (GameObject.Find("Player") == null)
         {
            return;
         }
        delta = lastHP - player.hp;
        lastHP = player.hp;
        hpBar.sizeDelta -= new Vector2(delta * unit, 0.0f);
    }
}
