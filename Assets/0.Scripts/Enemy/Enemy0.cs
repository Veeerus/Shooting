using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0 : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        HP = 100;
        Score = 20;
        Speed = Random.Range(4,6) * 0.1f;
        firePos = transform.GetChild(0);
        sa = GetComponent<SpriteAnimation>();

        sa.SetSprite(normalSprite, 0.2f);
    }
}
