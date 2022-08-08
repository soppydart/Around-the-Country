using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(GameObject.Find("ButtonClickAudioSource"));
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Rules");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
