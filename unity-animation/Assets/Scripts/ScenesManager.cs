using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public enum Scene
    {
        MainMenu,
        Options,
        Level01,
        Level02,
        Level03
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level01");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level02");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level03");
    }
}