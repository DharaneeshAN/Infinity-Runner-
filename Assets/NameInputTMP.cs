// NameInputTMP.cs
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NameInputTMP : MonoBehaviour
{
    public TMP_InputField nameInputField;

    public void SaveNameAndLoadNextScene()
    {
        PlayerData.PlayerName = nameInputField.text;
        SceneManager.LoadScene("WelcomeScene"); // Replace with your actual scene name
    }
}
