using UnityEngine;

public class VoiceRecorder : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip recordedClip;
    private bool isRecording = false;

    [Header("Assign in Inspector")]
    public Animator animator; // Drag your Animator here
    public AnimationClip startRecordingClip; // Drag recording animation here
    public AnimationClip playBackClip;       // Drag playback animation here

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.playOnAwake = false;

        if (animator == null)
            Debug.LogWarning("Animator not assigned in inspector!");
    }

    public void StartRecording()
    {
        if (Microphone.devices.Length == 0)
        {
            Debug.LogWarning("No microphone detected!");
            return;
        }

        isRecording = true;
        Debug.Log("🎤 Recording...");
        recordedClip = Microphone.Start(null, false, 10, 44100); // record up to 10 seconds

        // Play animation if assigned
        if (animator != null && startRecordingClip != null)
            animator.Play(startRecordingClip.name);
    }

    public void PlayBack()
    {
        if (!isRecording) return;

        Microphone.End(null); // Stop recording
        isRecording = false;

        audioSource.clip = recordedClip;
        audioSource.pitch = 1.5f; // Funny cat voice pitch
        audioSource.volume = 1.0f; // Full volume
        audioSource.Play();

        Debug.Log("🔊 Playing back...");

        // Play animation if assigned
        if (animator != null && playBackClip != null)
            animator.Play(playBackClip.name);
    }
}
