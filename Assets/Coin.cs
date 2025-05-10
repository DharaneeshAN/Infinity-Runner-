using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed = 5f;
    private AudioSource audioSource;
    private bool isCollected = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollected = true;

            ScoreManager.instance.AddPoint();

            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }

            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            Destroy(gameObject, audioSource.clip.length);
        }
    }

    private void OnBecameInvisible()
    {
        if (!isCollected) // Only trigger if not already collected
        {
            isCollected = true; // Prevent multiple calls

            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<Collider>().enabled = false;
                Destroy(gameObject, audioSource.clip.length);
            }
            else
            {
                Destroy(gameObject); // Fallback if no sound
            }
        }
    }
}
