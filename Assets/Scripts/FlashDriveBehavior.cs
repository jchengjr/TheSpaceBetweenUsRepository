using UnityEngine;

public class FlashDriveBehavior : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;

    public void Collect()
    {
        levelManager.CollectDrive();
        GameObject.Destroy(gameObject);
    }
}