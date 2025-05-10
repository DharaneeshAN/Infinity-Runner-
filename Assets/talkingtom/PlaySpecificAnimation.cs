using UnityEngine;

public class PlaySpecificAnimation : MonoBehaviour
{
    // Reference to the Animation component
    public Animation modelAnimation;

    // Reference to the animation clip you want to play
    public AnimationClip animationClip;

    // Play the selected animation
    public void PlayAnimation()
    {
        if (modelAnimation != null && animationClip != null)
        {
            modelAnimation.clip = animationClip;
            modelAnimation.Play();
        }
        else
        {
            Debug.LogError("ModelAnimation or AnimationClip is not assigned!");
        }
    }
}
