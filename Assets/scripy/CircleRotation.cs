using UnityEngine;

public class CircleRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private int direction = 1;

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * direction * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            direction *= -1;
        }
    }
}