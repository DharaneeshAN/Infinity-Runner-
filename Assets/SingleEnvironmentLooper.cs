using UnityEngine;

public class SingleEnvironmentLooper : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float resetPositionZ = -30f;
    public float startPositionZ = 60f;

    private float fixedX;
    private float fixedY;

    void Start()
    {
        // Store the original X and Y to lock them
        fixedX = transform.position.x;
        fixedY = transform.position.y;
    }

    void Update()
    {
        // Move backward on Z only
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        if (transform.position.z < resetPositionZ)
        {
            // Reset only the Z position, keep X and Y locked
            transform.position = new Vector3(fixedX, fixedY, startPositionZ);
        }
    }
}
