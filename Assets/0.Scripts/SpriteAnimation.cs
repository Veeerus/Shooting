using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAnimation : MonoBehaviour
{
    private SpriteRenderer sr;
    private List<Sprite> sprite;
    private float delay;
    UnityAction action;
    bool loop;
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
                if (loop)
                    animIndex = 0;
                else
                {
                    sprite.Clear();
                    if(action != null)
                    {
                        action();
                        action = null;
                    }
                }
            }
        }
    }
    public void SetSprite(List<Sprite> sprite,float delay)
    {
        animIndex = 0;
        this.sprite = sprite.ToList();
        this.delay = delay;
        action = null;
        loop = true;
        if (sr == null)
            sr = GetComponent<SpriteRenderer>();
        sr.sprite = this.sprite[0];
        animIndex = 0;
    }
    public void SetSprite(List<Sprite>sprite,float delay,UnityAction action)
    {
        animIndex = 0;
        this.sprite = sprite.ToList();
        this.delay = delay;
        this.action = action;
        loop = false;
        if (sr == null)
            sr = GetComponent<SpriteRenderer>();
        sr.sprite = this.sprite[0];
        animIndex = 0;
    }
}
