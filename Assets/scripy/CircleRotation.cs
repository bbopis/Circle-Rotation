using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CircleRotation : MonoBehaviour
{
    public int score = 0;
    private bool isGameOver = false;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;

    public GameObject bulletPrefab;
    public Transform firePoint;

    private Color[] colors = { Color.red, Color.blue, Color.green };
    private int currentColor = 0;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        scoreText.text = "Score: 0";
        Time.timeScale = 1f;

        sr.color = colors[currentColor];
    }

    void Update()
    {
        if (isGameOver) return;

        // 🖱 rotate toward mouse
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector3 dir = mousePos - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        // 🎨 SPACE = change color
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentColor = (currentColor + 1) % colors.Length;
            sr.color = colors[currentColor];
        }

        // 🔫 CLICK = shoot
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (isGameOver) return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);

        Bullet b = bullet.GetComponent<Bullet>();
        if (b == null)
        {
            Debug.LogError("Bullet script missing!");
            return;
        }

        Vector2 dir = transform.up;
        b.SetDirection(dir);

        // 🎨 match color
        SpriteRenderer bulletSR = bullet.GetComponent<SpriteRenderer>();
        bulletSR.color = sr.color;
        b.bulletColor = sr.color;
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isGameOver) return;

        if (other.CompareTag("Obstacle"))
        {
            isGameOver = true;
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}