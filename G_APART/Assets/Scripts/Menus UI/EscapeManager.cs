using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public bool isPaused;
   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!settingsMenu.activeSelf)
                pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
        }

        if (pauseMenu.activeSelf || settingsMenu.activeSelf)
        {
            isPaused = true;
            TimeScaler.instance.PauseTime();
        }
        else
        {
            isPaused = false;
            TimeScaler.instance.ResumeTime();
        }
    }

    public void ChangeScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
