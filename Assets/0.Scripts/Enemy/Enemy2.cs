using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    void Start()
    {
        HP = 400;
        Score = 20;
        Speed = Random.Range(1, 3) * 0.1f;
        firePos = transform.GetChild(0);
        sa = GetComponent<SpriteAnimation>();

        sa.SetSprite(normalSprite, 0.2f);
    }
}
