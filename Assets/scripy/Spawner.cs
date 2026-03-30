using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public GameObject obstaclePrefab;

    public float spawnInterval = 1.5f;

    void Start()
{
    float randomDelay = Random.Range(0f, 1.5f);
    InvokeRepeating("SpawnObject", randomDelay, spawnInterval);
}

   void SpawnObject()
{
    GameObject obj;

    if (Random.value > 0.5f)
        obj = Instantiate(collectiblePrefab, transform.position, Quaternion.identity);
    else
        obj = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);

    // direction = toward center (0,0)
    Vector2 dir = transform.right;

    obj.GetComponent<MovingObject>().SetDirection(dir);
}
}