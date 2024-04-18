using UnityEngine;
using UnityEngine.UI;

public class HoverSound : MonoBehaviour
{
    public AudioSource hoverSound;

    void Start()
    {
        // Assuming the AudioSource component is attached to the MenuSFX/RolloverSound GameObject
        hoverSound = GameObject.Find("MenuSFX/RolloverSound").GetComponent<AudioSource>();
    }

    public void OnPointerEnter()
    {
        hoverSound.Play();
    }
}
