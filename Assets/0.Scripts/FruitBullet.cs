using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBullet : MonoBehaviour
{
    public float Power { get; set; } = 20;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.up * Time.deltaTime * -10f);

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<endline>())
        {
            Destroy(collision.gameObject);
        }
    }
}
