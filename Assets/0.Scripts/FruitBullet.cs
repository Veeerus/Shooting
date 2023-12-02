using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBullet : MonoBehaviour
{
    public float Power { get; set; } = 20;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D Circle)
    {
        if (Circle.transform.GetComponent<FruitBullet>())
        {
            return;
        }
    }
}
