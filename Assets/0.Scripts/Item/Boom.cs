using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : Item
{
    [SerializeField] private List<Sprite> boomSprite;
    [SerializeField] private GameObject boom0bj;
    // Start is called before the first frame update
    void Start()
    {
        DownSpeed = 0.2f;
        GetComponent<SpriteAnimation>().SetSprite(sprites, 0.1f);
    }
    public void Play()
    {
        GameObject obj = Instantiate(boom0bj);
        FindObjectOfType<EnemyController>().EnemyAffDelete();
        obj.GetComponent<SpriteAnimation>().SetSprite(boomSprite, 0.1f,
            () =>
            {
                Destroy(obj);

            }
        );
    }
    
}
