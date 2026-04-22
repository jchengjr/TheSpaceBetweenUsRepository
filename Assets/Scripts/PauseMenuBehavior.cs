using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuBehavior : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    bool isGamePaused = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1f;
        pauseMenuPanel.SetActive(false);
        Cursor.visible = false;
        ToggleStickyCursor();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0f;
        pauseMenuPanel.SetActive(true);
        Cursor.visible = true;
        ToggleStickyCursor();
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartGame()
    {
        ResumeGame();
        SafeBehavior.isOpened = false;
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadMainMenu()
    {
        // Debug.Log("Main menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    private void ToggleStickyCursor()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        WebGLInput.stickyCursorLock = isGamePaused;
#endif
    }
}