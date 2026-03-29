using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private int drivesToCollect = 3;

    [SerializeField]
    private GameObject laserParticles;

    [SerializeField]
    private TextMeshPro computerText;

    private int drivesCollected = 0;

    public void CollectDrive()
    {
        drivesCollected++;
    }

    private void EndGame()
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
