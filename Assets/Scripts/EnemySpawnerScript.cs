using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bossPrefab;
    public BoxCollider2D box;
    public Transform bossSpawnPos;

    public float bossSpawnerTimer = 15f;
    public float cooldown = 2f;

    private float enemyTimer;
    private float bossTimer;
    
    void Start()
    {
        enemyTimer = cooldown;
        bossTimer = bossSpawnerTimer;
    }

    void Update()
    {
        enemyTimer -= Time.deltaTime;
        if (enemyTimer <= 0f)
        {
            enemyTimer = cooldown;
            SpawnEnemy(enemyPrefab);
        }

        bossTimer -= Time.deltaTime;
        if (bossTimer <= 0)
        {
            bossTimer = bossSpawnerTimer;
            SpawnBoss(bossPrefab);
        }

    }

    void SpawnEnemy(GameObject prefab)
    {
        GameObject newEnemy = Instantiate(prefab);

        float randomPos = Random.Range(box.bounds.min.x, box.bounds.max.x);
        newEnemy.transform.position = new Vector3(randomPos, transform.position.y);
    }

    void SpawnBoss(GameObject prefab)
    {
        GameObject newBoss = Instantiate(prefab);
        newBoss.transform.position = bossSpawnPos.position;
    }

}
