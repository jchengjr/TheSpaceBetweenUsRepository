using UnityEngine;

public class BookBehavior : MonoBehaviour
{
    public static bool isTouched = false;
    public float doorSpeed = 30;
    public Transform SpawnLocation;
    public GameObject drivePrefab;

    private bool spawnedDrive = false;
    bool doorRotate = true;

    // Update is called once per frame
    void Update()
    {
        if(isTouched && doorRotate)
        {
            Debug.Log("go");
            transform.Rotate(Vector3.forward, doorSpeed * Time.deltaTime);
            // Debug.Log(transform.rotation.x);

            SpawnDrive();
        }
        if(transform.rotation.x >= 0.2)
        {
            Debug.Log("stop");
            doorRotate = false;
        }
    }

    private void SpawnDrive()
    {
        if (!spawnedDrive)
        {
            Instantiate(drivePrefab, SpawnLocation);
            spawnedDrive = true;
        }
    }
}
