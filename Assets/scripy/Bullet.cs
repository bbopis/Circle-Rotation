using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Color bulletColor;

    private Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other || !other.gameObject) return;

        if (other.CompareTag("Obstacle"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (!enemy) return;

            // 🎯 COLOR CHECK
            if (Vector4.Distance(enemy.enemyColor, bulletColor) < 0.2f)
            {
                Debug.Log("COLOR MATCH → DESTROY");

                // ✅ ADD SCORE
                CircleRotation player = FindFirstObjectByType<CircleRotation>();
                if (player != null)
                {
                    player.AddScore(1);
                }

                // ✅ DISABLE FIRST (IMPORTANT)
                other.gameObject.SetActive(false);
                gameObject.SetActive(false);

                // ✅ DESTROY AFTER DELAY
                Destroy(other.gameObject, 0.05f);
                Destroy(gameObject, 0.05f);
            }
            else
            {
                // wrong color → destroy bullet only
                gameObject.SetActive(false);
                Destroy(gameObject, 0.05f);
            }
        }
    }
}