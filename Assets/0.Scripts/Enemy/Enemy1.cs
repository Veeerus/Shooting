using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        HP = 200;
        Score = 20;
        Speed = Random.Range(2, 5) * 0.1f;
        firePos = transform.GetChild(0);
        sa = GetComponent<SpriteAnimation>();

        sa.SetSprite(normalSprite, 0.2f);
    }
}
