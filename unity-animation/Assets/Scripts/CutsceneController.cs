using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject playerController;
    public GameObject timerCanvas;
    public GameObject cutsceneController;

    public void TransitionToGameplay()
    {
        // Enable MainCamera
        mainCamera.gameObject.SetActive(true);

        // Enable PlayerController
        playerController.SetActive(true);

        // Enable TimerCanvas
        timerCanvas.SetActive(true);

        // Disable CutsceneController
        cutsceneController.SetActive(false);
    }
}
