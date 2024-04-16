using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject playerController;
    public GameObject timerCanvas;
    public GameObject cutsceneCamera;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        mainCamera.SetActive(false);
        timerCanvas.SetActive(false);
        cutsceneCamera.SetActive(true); 
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Intro01") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            // Enable Main Camera and TimerCanvas
            mainCamera.SetActive(true);
            timerCanvas.SetActive(true);

            // Disable CutsceneCamera
            cutsceneCamera.SetActive(false);

            // Enable PlayerController Script
            PlayerController playerControllerScript = playerController.GetComponent<PlayerController>();
            if (playerControllerScript != null)
                playerControllerScript.enabled = true;
        }
    }
}