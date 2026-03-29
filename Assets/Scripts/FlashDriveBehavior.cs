using UnityEngine;

public class FlashDriveBehavior : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;

    private void Start()
    {
        if (!levelManager)
        {
            levelManager = FindAnyObjectByType<LevelManager>();
        }
    }
    public void Collect()
    {
        levelManager.CollectDrive();
        GameObject.Destroy(gameObject);
    }
}