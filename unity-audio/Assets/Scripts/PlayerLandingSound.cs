using UnityEngine;

public class PlayerLandingSound : MonoBehaviour
{
    public AudioClip grassLandingClip;
    public AudioClip rockLandingClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GrassPlatform"))
        {
            audioSource.PlayOneShot(grassLandingClip);
        }
        else if (collision.gameObject.CompareTag("StonePlatform"))
        {
            audioSource.PlayOneShot(rockLandingClip);
        }
    }
}

