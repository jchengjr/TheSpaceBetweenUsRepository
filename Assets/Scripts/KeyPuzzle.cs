using UnityEngine;

public class KeyPuzzle : MonoBehaviour
{
    public static bool keyHeld = false;
    public GameObject keyHeldPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(keyHeld)
        {
            keyHeldPrefab.SetActive(true);
        }
    }

    void KeyInteraction()
    {
        
    }
}
