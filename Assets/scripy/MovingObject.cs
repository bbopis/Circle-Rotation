using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed = 3f;
    private Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}