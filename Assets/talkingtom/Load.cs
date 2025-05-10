using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    [Tooltip("Name of the scene to load. Make sure it's added to Build Settings.")]
    public string sceneName; // Set this from the Inspector

    public void LoadScene()
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogWarning("Scene name is not set!");
            return;
        }

        SceneManager.LoadScene(sceneName);
    }
}
