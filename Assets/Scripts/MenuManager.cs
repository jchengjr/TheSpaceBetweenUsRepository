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
            runText.text = "Number of Playthroughs: " + PlayerPrefs.GetFloat("RunValue", 0);
        }
    }
    public void StartGame()
    {
        PlayerPrefs.SetFloat("RunValue", PlayerPrefs.GetFloat("RunValue", 0) + 1);
        SceneManager.LoadScene("SampleScene");
    }
}
