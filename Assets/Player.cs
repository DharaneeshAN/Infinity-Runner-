using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 7f;
    private bool canJump = true;

    public TextMeshProUGUI scoreText; // Assign in Inspector
    private int score = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        UpdateScoreUI();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canJump)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Cancel vertical velocity
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        canJump = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the current scene
        }
        else if (other.CompareTag("ScoreZone"))
        {
            score++;
            UpdateScoreUI();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}