using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TMP_Text runText;
    public void Start()
    {
        if (runText)
        {
            runText.text = "Playtime: " + PlayerPrefs.GetFloat("Playtime", 0);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
