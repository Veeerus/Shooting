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
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sprite == null || sprite.Count == 0)
            return;

        timer += Time.deltaTime;
        if(timer >= delay)
        {
            timer = 0;

            sr.sprite = sprite[animIndex];
            animIndex++;

            if (sprite.Count <= animIndex)
            {
                if(loop)
                    animIndex = 0;
                else
                {
                    sprite.Clear();
                    if (action != null)
                    {
                        action();
                        action = null;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 이미지 반복 함수 
    /// </summary>
    public void SetSprite(List<Sprite> sprite, float delay,bool loop = true)
    {
        this.sprite = sprite.ToList();
        this.delay = delay;
        action = null;
        this.loop = loop;

        if(sr == null)
            sr = GetComponent<SpriteRenderer>();

        sr.sprite = sprite[0];
        animIndex = 0;
    }

    public void SetSprite(List<Sprite> sprite, float delay, UnityAction action)
    {
        this.sprite = sprite.ToList();
        this.delay = delay;
        this.action = action;
        loop = false;

        if (sr == null)
            sr = GetComponent<SpriteRenderer>();

        sr.sprite = sprite[0];
        animIndex = 0;
    }
}
