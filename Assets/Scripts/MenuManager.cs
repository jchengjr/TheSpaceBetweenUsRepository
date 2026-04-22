using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TMP_Text runText;
    public GameObject overview;
    bool readingOverview = false;
    public void Start()
    {
        if (runText)
        {
            runText.text = "Playtime: " + PlayerPrefs.GetFloat("Playtime", 0);
        }
    }
    public void StartGame()
    {
        if(!readingOverview)
            SceneManager.LoadScene("SampleScene");
    }

    public void OverView()
    {
        readingOverview = true;
        overview.SetActive(true);
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire2") && readingOverview)
        {
            readingOverview = false;
            overview.SetActive(false);
        }
    }
}
