using UnityEngine;

public class LoopingRoad : MonoBehaviour
{
    public float scrollSpeed = 100f;
    public float roadLength = 100f;
    public float speedIncreaseRate = 2f;

    private Vector3 startPos;
    private float fixedX; // To lock X position
    private float fixedY;

    void Start()
    {
        startPos = transform.position;
        fixedX = startPos.x;
        fixedY = startPos.y;
    }

    void Update()
    {
        // Gradually increase scroll speed
        scrollSpeed += speedIncreaseRate * Time.deltaTime;

        // Move only along Z axis
        transform.Translate(Vector3.back * scrollSpeed * Time.deltaTime, Space.World);

        // Lock X and Y position to prevent sideways drifting
        Vector3 pos = transform.position;
        pos.x = fixedX;
        pos.y = fixedY;
        transform.position = pos;

        // Loop the road
        if (transform.position.z < -roadLength)
        {
            transform.position = new Vector3(fixedX, fixedY, transform.position.z + roadLength * 2);
        }
    }
}
