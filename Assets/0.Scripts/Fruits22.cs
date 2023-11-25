using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits22 : MonoBehaviour
{
    [SerializeField] private Transform bulletParent;
    [SerializeField] private float fireBulletDelayTime;
    [SerializeField] private GameObject[] bullets;

    private float fireDealyTimer;



    public int BulletLevel { get; set; } = 1;   // ¾µ¸ð x
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        Fire();
    }




    void Fire()
    {
        fireDealyTimer += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (fireDealyTimer > fireBulletDelayTime)
            {
                fireDealyTimer = 0;
                GameObject obj = Instantiate(bullets[BulletLevel - 1], transform.GetChild(0));
                obj.transform.SetParent(bulletParent);
            }
        }
    }
}


//