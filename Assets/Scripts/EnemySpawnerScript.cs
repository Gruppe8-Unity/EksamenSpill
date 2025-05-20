using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemyPrefab;
    public BoxCollider2D box;
    public float cooldown;

    private float timer;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = cooldown;

            GameObject newEnemy = Instantiate(enemyPrefab);

            float randomPos = Random.Range(box.bounds.min.x, box.bounds.max.x);
            newEnemy.transform.position = new Vector3(randomPos, transform.position.y);
        }

    }

}
