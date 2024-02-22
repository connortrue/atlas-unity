using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Text winText; // Reference to the Text component to modify
    public int fontSizeIncrease =  60; // The amount by which to increase the font size

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Timer>().StopTimer();
            winText.fontSize += fontSizeIncrease;
            winText.color = Color.green;
        }
    }
}
