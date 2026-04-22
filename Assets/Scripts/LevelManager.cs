using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public TMP_Text driveNumText;

    [SerializeField]
    private int drivesToCollect = 3;

    [SerializeField]
    private GameObject laserParticles;

    [SerializeField]
    private TMP_Text computerText;

    [SerializeField]
    private GameObject NPC;

    private int drivesCollected;

    private float timer = 0;

    public void Start()
    {
        timer = 0f;
    }

    public void Update()
    {
        timer += Time.deltaTime;
    }

    public void CollectDrive()
    {
        drivesCollected++;
        UpdateDriveText();
    }

    public void EndGame()
    {
        if (drivesCollected >= drivesToCollect)
        {
            Victory();
        } else
        {
            Defeat();
        }
        PlayerPrefs.SetFloat("Playtime", timer + PlayerPrefs.GetFloat("Playtime", 0));
    }

    private void Victory()
    {
        laserParticles.SetActive(true);
        computerText.text = "Congratulations.";
        NPC.SetActive(true);
    }

    private void Defeat()
    {
        computerText.text = "I'm sorry...";
        MouseLook.canMove = false;
    }

    void UpdateDriveText()
    {
        driveNumText.text = "Drives Collected:" + drivesCollected.ToString();
    }
}
