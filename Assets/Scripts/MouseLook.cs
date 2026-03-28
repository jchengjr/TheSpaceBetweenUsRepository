using Unity.Mathematics;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float pitchMin = -90f;
    public float pitchMax = 90f;

    public float raycastRange = 3;
    public TMP_Text computerObjectText;
    public GameObject computerPuzzle;
    public static bool canMove = true;
    public TMP_Text code1;
    public TMP_Text code2;
    public TMP_Text code3;
    public TMP_Text code4;
    int codeNum;
    string key;

    bool computerFound = false;

    Transform playerBody;
    float pitch;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerBody = transform.parent.transform;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        codeNum = 0;

        key = "_";
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        ComputerPuzzle();

        if(Input.anyKeyDown && computerPuzzle.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.Backspace))
            {
                code1.SetText("_");
                code2.SetText("_");
                code3.SetText("_");
                code4.SetText("_");
                codeNum = 0;
            }
            else if((Input.inputString.CompareTo("a") > 0 || Input.inputString.CompareTo("a") == 0) 
                && (Input.inputString.CompareTo("z") < 0 || Input.inputString.CompareTo("z") == 0))
            {
                key = Input.inputString.ToUpper();
                Debug.Log(key);
                codeNum++;
            }
        }
    
        switch(codeNum)
        {
            case 1:
                code1.SetText(key);
                break;
            case 2:
                code2.SetText(key);
                break;
            case 3:
                code3.SetText(key);
                break;
            case 4:
                code4.SetText(key);
                break;
        }

        if(code1.text.Equals("C") && code2.text.Equals("O") && code3.text.Equals("D") && code4.text.Equals("E") 
            && Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Code cracked");
        }
    }

    void Move()
    {
        if(!canMove)
        {
            return;
        }

        float moveX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float moveY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // yaw (player)
        if(playerBody)
            playerBody.Rotate(Vector3.up * moveX);

        // pitch (camera)
        pitch -= moveY;
        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);
        transform.localRotation = Quaternion.Euler(pitch, 0, 0);

        // Debug.Log("Mouse X:" + moveX);
    }

    void FixedUpdate()
    {
        InteractiveEffect();
    }

    void InteractiveEffect()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, raycastRange))
        {
            // Debug.Log("Hit something: " + hit.collider.name);

            if(hit.collider.CompareTag("Computer"))
            {
                computerObjectText.gameObject.SetActive(true);
                computerFound = true;
            }
            else
            {
                computerObjectText.gameObject.SetActive(false);
                computerFound = false;
            }
        }
    }

    void ComputerPuzzle()
    {
        if(computerFound && !computerPuzzle.activeSelf && Input.GetButtonDown("Fire1"))
        {
            computerPuzzle.SetActive(true);
            canMove = false;
        }

        if(computerPuzzle.activeSelf)
        {
            if(Input.GetButtonDown("Fire2"))
            {
                computerPuzzle.SetActive(false);
                canMove = true;
            }
        }
    }
}
