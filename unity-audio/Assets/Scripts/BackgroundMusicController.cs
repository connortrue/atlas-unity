using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Stop the music if the player touches the WinFlag
        /*if (/* TD: pull the condition to check if the player has touched the WinFlag )
        {
            audioSource.Stop();
        }*/
        
    }
}

