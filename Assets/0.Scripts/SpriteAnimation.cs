using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAnimation : MonoBehaviour
{
    private SpriteRenderer sr;
    private List<Sprite> sprite;
    private float delay;
    int animIndex = 0;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (sprite.Count == 0)
            return;
        timer += Time.deltaTime;
        if (timer >= delay)
        {
            timer = 0;

            sr.sprite = sprite[animIndex];
            animIndex++;
            if (sprite.Count <= animIndex)
            {
                animIndex = 0;
            }
        }
    }
    public void SetSprite(List<Sprite> sprite,float delay)
    {
        animIndex = 0;
        this.sprite = sprite;
        this.delay = delay;
        if (sr == null)
            sr = GetComponent<SpriteRenderer>();
        sr.sprite = this.sprite[0];
        animIndex = 0;
    }
}
