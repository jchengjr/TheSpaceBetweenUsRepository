using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private int drivesToCollect = 3;

    [SerializeField]
    private GameObject laserParticles;

    [SerializeField]
    private TMP_Text computerText;

    private int drivesCollected = 0;

    public void CollectDrive()
    {
        drivesCollected++;
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
    }

    private void Victory()
    {
        laserParticles.SetActive(true);
        computerText.text = "Congratulations.";
    }

    private void Defeat()
    {
        computerText.text = "I'm sorry...";
    }
}
