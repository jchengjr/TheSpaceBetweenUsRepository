using Unity.VisualScripting;
using UnityEngine;

public class SafeBehavior : MonoBehaviour
{
    public static bool isOpened = false;
    public Transform door;
    public float doorSpeed = 30;
    bool doorRotate = true;
    
    // Update is called once per frame
    void Update()
    {
        if(isOpened && doorRotate)
        {
            door.Rotate(Vector3.up, doorSpeed * Time.deltaTime);
            // Debug.Log(door.rotation.y);
        }
        if(door.rotation.y >= 0.8)
        {
            doorRotate = false;
        }
    }
}
