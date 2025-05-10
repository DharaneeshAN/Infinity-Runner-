using UnityEngine;

public class PlayLoopingAnimationOnButton : MonoBehaviour
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

        // Add the clip if it's not already in the animation component
        if (!targetAnimation.GetClip(animationToPlay.name))
        {
            targetAnimation.AddClip(animationToPlay, animationToPlay.name);
        }

        // Set loop mode
        animationToPlay.wrapMode = WrapMode.Loop;
        targetAnimation.wrapMode = WrapMode.Loop;

        targetAnimation.Play(animationToPlay.name);
    }
}
