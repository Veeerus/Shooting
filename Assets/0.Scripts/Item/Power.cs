using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : Item
{
    // Start is called before the first frame update
    void Start()
    {
        DownSpeed = 0.2f;
        GetComponent<SpriteAnimation>().SetSprite(sprites, 0.1f);
    }

    
}
