using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    enum Direction
    {
        Center,
        Left,
        Right,
    }
    [SerializeField] private List<Sprite> normalSprite;
    [SerializeField] private List<Sprite> leftSprite;
    [SerializeField] private List<Sprite> rightSprite;
    [SerializeField] private float speed;
    [SerializeField] private Transform bulletParent;
    [SerializeField] private float fireBulletDelayTime;
    [SerializeField] private PBullet bullet;
    private Direction dir = Direction.Center;
    private float fireDelayTimer;
    
    // Start is called before the first frame update
    //float �� �ڷ��� ���� Ŭ������ ����
    //Transform �� PBullet �� Ŭ�����̴�
    void Start()
    {
        GetComponent<SpriteAnimation>().SetSprite(normalSprite, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
        //transform.Translate(new Vector3(x, y, 0f) * Time.deltaTime * 6f);
    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 6f;
        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * 6f;

        // -2.3 - 2.3
        float clampX = Mathf.Clamp(transform.position.x + x, -2.3f, 2.3f);
        float clampY = Mathf.Clamp(transform.position.y + y, -4.5f, 4.5f);
        transform.position = new Vector2(clampX, clampY);
        if (x < 0 && dir != Direction.Left)
        {
            dir = Direction.Left;
            GetComponent<SpriteAnimation>().SetSprite(leftSprite, 0.2f);
        }
        else if (x > 0 && dir != Direction.Right)
        {
            dir = Direction.Right;
            GetComponent<SpriteAnimation>().SetSprite(rightSprite, 0.2f);
        }
        else if (x == 0 && dir != Direction.Center)
        {
            dir = Direction.Center;
            GetComponent<SpriteAnimation>().SetSprite(normalSprite, 0.2f);
        }
        //transform.Translate(new Vector3(x, y, 0f) * Time.deltaTime * 6f);
    }
    void Fire()
    {
        fireDelayTimer += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (fireDelayTimer > fireBulletDelayTime)
            {
                fireDelayTimer = 0;
                PBullet b = Instantiate(bullet, transform.GetChild(0));
                b.transform.SetParent(bulletParent);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EBullet>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
//�ڵ尡 player�� �֤�,�Ѥ���