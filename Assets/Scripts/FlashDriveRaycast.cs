using UnityEngine;

public class FlashDriveRaycast : MonoBehaviour
{
    [SerializeField]
    private float rayCastRange = 3f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckRaycast();
        }
    }

    private void CheckRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayCastRange))
        {
            CheckForFlashDrive(hit.collider.gameObject);
        }
    }

    private void CheckForFlashDrive(GameObject target)
    {
        if (target.CompareTag("FlashDrive"))
        {
            target.GetComponent<FlashDriveBehavior>().Collect();
        } else if (target.CompareTag("EndGameComputer"))
        {
            target.GetComponent<ComputerBehavior>().Activate();
        }
    }
}
