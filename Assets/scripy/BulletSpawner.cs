using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootInterval = 1f;

    private SpriteRenderer playerSR;

    void Start()
    {
        playerSR = GetComponentInParent<SpriteRenderer>();

        InvokeRepeating("Shoot", 1f, shootInterval);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        Bullet b = bullet.GetComponent<Bullet>();

        Vector2 dir = transform.up;
        b.SetDirection(dir);

        // 🎨 match color
        SpriteRenderer bulletSR = bullet.GetComponent<SpriteRenderer>();
        bulletSR.color = playerSR.color;
        b.bulletColor = playerSR.color;
    }
}