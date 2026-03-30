using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CircleRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;

    private int direction = 1;
    public int score = 0;
    private bool isGameOver = false;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;

    void Start()
    {
        scoreText.text = "Score: 0";
        Time.timeScale = 1f; // reset time on start
    }

    void Update()
    {
        if (isGameOver) return;

        transform.Rotate(0, 0, rotationSpeed * direction * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            direction *= -1;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isGameOver) return;

        if (other.CompareTag("Collectible"))
        {
            score++;
            scoreText.text = "Score: " + score;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Obstacle"))
        {
            isGameOver = true;
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    // 🔁 Restart function
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}