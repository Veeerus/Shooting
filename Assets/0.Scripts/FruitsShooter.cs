using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsShooter : MonoBehaviour
{
    [SerializeField] private float fireBulletDelayTime;
    [SerializeField] private GameObject[] bullets;
    private float fireDealyTimer;
    [SerializeField] private Transform bulletParent;
    public int BulletLevel { get; set; } = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
