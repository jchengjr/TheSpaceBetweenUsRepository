using UnityEngine;

public class KeyPuzzle : MonoBehaviour
{
    public static bool keyFound = false;
    public static bool safeFound = false;
    public GameObject keyFoundPrefab;
    public GameObject keyHeldPrefab;
    bool keyHeld = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KeyInteraction();
    }

    void KeyInteraction()
    {
        if(!keyHeld && keyFound && Input.GetButtonDown("Fire1"))
        {
            // pickup key
            keyFoundPrefab.SetActive(false);
            keyHeldPrefab.SetActive(true);
            keyHeld = true;
        }
        else if(keyHeld && safeFound && Input.GetButtonDown("Fire1"))
        {
            // use key
            keyHeldPrefab.SetActive(false);
            keyHeld = false;
            SafeBehavior.isOpened = true;
        }
    }
}
