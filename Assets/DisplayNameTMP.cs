// DisplayNameTMP.cs
using UnityEngine;
using TMPro;

public class DisplayNameTMP : MonoBehaviour
{
    public TMP_Text nameDisplayText;

    void Start()
    {
        nameDisplayText.text = "Welcome, " + PlayerData.PlayerName + "!";
    }
}
