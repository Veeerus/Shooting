using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Enemy[] enemys;
    [SerializeField] private Player p;

    float spawnTimer;
    const float spawnTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UI.instance == null || UI.instance.gameState != GameState.Play)
            return;
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= spawnTime)
        {
            spawnTimer = 0;
            int rand = Random.Range(0, 100);
            int spawnIndex = rand < 70 ? 0 : rand < 90 ? 1 : 2;
            Enemy e = Instantiate(enemys[spawnIndex], Return_RandomPosition(), Quaternion.identity);
            e.SetPlayer(p);
        }
    }

    // ���� ���� 
    // ������ ����� Plane�� �ڽ��� RespawnRange ������Ʈ
    public GameObject rangeObject;
    BoxCollider2D rangeCollider;

    private void Awake()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider2D>();
    }

    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;
        // �ݶ��̴��� ����� �������� bound.size ���
        float range_X = rangeCollider.bounds.size.x;
        float range_Y = rangeCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Y = Random.Range((range_Y / 2) * -1, range_Y / 2);
        Vector3 RandomPostion = new Vector3(range_X, range_Y, 0f);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }
}
