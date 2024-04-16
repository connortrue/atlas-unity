using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float timer;
    private bool isRunning = false; // Flag to check if the timer is running

    private void OnEnable()
    {
        timer =  0f;
    }

    private void Update()
    {
        if (isRunning && timer >  0)
        {
            timer += Time.deltaTime;
            timerText.text = FormatTime(timer);
        }
    }

    public void StartTimer()
    {
        timer =  1f; // Start from  1 second to avoid displaying  0:00.00
        isRunning = true; // Set the timer to running
    }

    public void StopTimer()
    {
        timer =  0f; // Set the timer to  0
        isRunning = false; // Set the timer to stopped
    }

    private string FormatTime(float time)
    {
        int minutes = (int)(time /  60);
        int seconds = (int)(time %  60);
        int milliseconds = (int)((time *  100) %  100);

        return string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }
}
