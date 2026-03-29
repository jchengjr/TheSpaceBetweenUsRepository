using UnityEngine;

public class BookBehavior : MonoBehaviour
{
    public static bool isTouched = false;
    public float doorSpeed = 30;
    bool doorRotate = true;

    // Update is called once per frame
    void Update()
    {
        if(isTouched && doorRotate)
        {
            transform.Rotate(Vector3.forward, doorSpeed * Time.deltaTime);
            // Debug.Log(transform.rotation.x);
        }
        if(transform.rotation.x >= 0.8)
        {
            doorRotate = false;
        }
    }
}
