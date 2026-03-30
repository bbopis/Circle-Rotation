using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;

    void Start()
{
    float startDelay = Random.Range(0f, 2f);
    Invoke(nameof(StartSpawning), startDelay);
}

void StartSpawning()
{
    StartCoroutine(SpawnRoutine());
}

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnEnemy();

            float delay = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(delay);
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);

        // 🎯 move toward center
        Vector2 dir = (Vector2.zero - (Vector2)transform.position).normalized;

        MovingObject move = enemy.GetComponent<MovingObject>();
        if (move != null)
        {
            move.SetDirection(dir);
        }

        // 🎨 random color
        SpriteRenderer sr = enemy.GetComponent<SpriteRenderer>();
        Enemy enemyScript = enemy.GetComponent<Enemy>();

        Color[] colors = { Color.red, Color.blue, Color.green };
        Color randomColor = colors[Random.Range(0, colors.Length)];

        sr.color = randomColor;
        enemyScript.enemyColor = randomColor;
    }
}