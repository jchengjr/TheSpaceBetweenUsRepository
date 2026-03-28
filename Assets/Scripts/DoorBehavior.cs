using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    [SerializeField]
    private AudioClip doorSFX;
    public void OpenDoor()
    {
        if (doorSFX)
        {
            AudioSource.PlayClipAtPoint(doorSFX, Camera.main.transform.position);
        }
        this.gameObject.SetActive(false);
        doorSFX = null;
    }
}
