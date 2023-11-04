using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected List<Sprite> sprites;
    public float DownSpeed { get; set; }
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * DownSpeed);
    }
}