using UnityEngine;

public class PlayAnimationOnButton : MonoBehaviour
{
    public Animation targetAnimation;             // Drag the model's Animation component here
    public AnimationClip animationToPlay;         // Drag the animation clip you want to play

    public void PlayAnimation()
    {
        if (targetAnimation == null || animationToPlay == null)
        {
            Debug.LogWarning("Missing Animation or AnimationClip!");
            return;
        }

        string clipName = animationToPlay.name;

        // Add the clip if not already added
        if (!targetAnimation.GetClip(clipName))
        {
            targetAnimation.AddClip(animationToPlay, clipName);
        }

        // Set the wrap mode of the animation state to Once (important!)
        targetAnimation[clipName].wrapMode = WrapMode.Once;

        // Stop any current animations
        targetAnimation.Stop();

        // Play the animation once
        targetAnimation.Play(clipName);
    }
}
