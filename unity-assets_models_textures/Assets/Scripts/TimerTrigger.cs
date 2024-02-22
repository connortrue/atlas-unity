using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
