using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed = 3f;
    private Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Update()
{
    if (!this || !gameObject || !gameObject.activeSelf) return;

    transform.position += (Vector3)(direction * speed * Time.deltaTime);
}
}