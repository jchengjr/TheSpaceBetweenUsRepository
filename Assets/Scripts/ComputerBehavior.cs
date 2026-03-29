using UnityEngine;

public class ComputerBehavior : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;

    public void Activate()
    {
        levelManager.EndGame();
    }
}
