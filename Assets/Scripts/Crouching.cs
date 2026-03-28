using UnityEngine;

public class Crouching : MonoBehaviour
{
    [SerializeField]
    private GameObject virtualCamera;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float crouchHeight = 1f;

    [SerializeField]
    private float crouchSpeed = 5f;

    [SerializeField]
    private float standSpeed = 10f;

    private float initialHeight;
    private bool isCrouching = false;
    void Start()
    {
        initialHeight = virtualCamera.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Crouch();
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            Stand();
        }
        if (isCrouching)
        {
            virtualCamera.transform.position = Vector3.Lerp(virtualCamera.transform.position, new Vector3(virtualCamera.transform.position.x, crouchHeight, virtualCamera.transform.position.z), Time.deltaTime * crouchSpeed);
        } else if (virtualCamera.transform.position.y != initialHeight)
        {
            virtualCamera.transform.position = Vector3.Lerp(virtualCamera.transform.position, new Vector3(virtualCamera.transform.position.x, initialHeight, virtualCamera.transform.position.z), Time.deltaTime * standSpeed);
        }
    }

    private void Crouch()
    {
        isCrouching = true;
        float sizeRatio = crouchHeight / initialHeight;
        player.transform.localScale = new Vector3(sizeRatio, sizeRatio, sizeRatio);
    }

    private void Stand()
    {
        isCrouching = false;
        player.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
