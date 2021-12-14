using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeScaler : MonoBehaviour
{
    public static TimeScaler instance;
    public bool timeIsStopped = false;
    public bool didCardSequence = false;

    public GameObject canvas;
    public TextMeshProUGUI lastWeekText;
    public TextMeshProUGUI currentObjText;
    private void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Update()
    {
        if(timeIsStopped && Input.GetMouseButtonDown(0))
        {
            PlayerSwitcher.instance.FadeToGame();
        }
    }

    public void StopTime()
    {
        timeIsStopped = true;
        Time.timeScale = 0f;
        if (!didCardSequence)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
            lastWeekText.text = "Last week's break-in was a success. You found and angered Porqins. His rage wreaked havoc on the building.";
            currentObjText.text = "This time... you want to free him.";
        }
        else
        {
            lastWeekText.text = "Last night's break-in has freed Porqins. He is now attempting to escape the building.";
            currentObjText.text = "Deal with this now or you are out of a job!";
        }

        canvas.SetActive(true);
    }
    public void StartTime()
    {
        canvas.SetActive(false);
        timeIsStopped = false;
        Time.timeScale = 1f;
    }
}
