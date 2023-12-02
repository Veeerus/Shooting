using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-0.05f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(0.05f, 0, 0);
        }
    }



    private void OnCollisionEnter2D(Collision2D Circle)
    {
        if (Circle.transform.GetComponent<FruitBullet>())
        {
            Destroy(Circle.gameObject);

        }
    }
}
