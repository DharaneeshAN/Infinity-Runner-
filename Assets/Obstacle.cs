using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 5f;
    private float fixedX; // Store the original X position

    void Start()
    {
        fixedX = transform.position.x;
    }

    void Update()
    {
        // Lock X position
        Vector3 position = transform.position;
        position.x = fixedX;
        transform.position = position;

        // Move backward along Z-axis
        transform.Translate(0, 0, -speed * Time.deltaTime, Space.World);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject); // Remove the obstacle when off screen
    }
}
