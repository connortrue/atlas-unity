using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    private Timer timerScript;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timerScript = other.gameObject.GetComponent<Timer>();
            if (timerScript != null)
            {
                timerScript.StartTimer();
            }
        }
    }
}
