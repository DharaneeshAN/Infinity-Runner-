using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [Tooltip("Enter the name of the scene to load")]
    public string sceneToLoad;

    public void ChangeScene()
    {
        if (string.IsNullOrEmpty(sceneToLoad))
        {
            Debug.LogWarning("Scene name is empty! Please assign a scene name in the Inspector.");
            return;
        }

        SceneManager.LoadScene(sceneToLoad);
    }
}
