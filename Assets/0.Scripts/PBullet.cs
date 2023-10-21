using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float Power { get; set; }

    void Start()
    {
        Destroy(gameObject, 5f);
        float p = Power;
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * 10f);
    }
}
//변수터럼 쓰는함수 get set이 있으면 함수의()가 빠짐