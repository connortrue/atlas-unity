using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float timer;

    private void OnEnable()
    {
        timer =  0f;
    }

    private void Update()
    {
        if (timer >  0)
        {
            timer += Time.deltaTime;
            timerText.text = FormatTime(timer);
        }
    }

    public void StartTimer()
    {
        timer =  1f; // Start from  1 second to avoid displaying  0:00.00
    }

    private string FormatTime(float time)
    {
        int minutes = (int)(time /  60);
        int seconds = (int)(time %  60);
        int milliseconds = (int)((time *  100) %  100);

        return string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }
}
