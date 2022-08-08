using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ReturnToGame()
    {
        FindObjectOfType<GameController>().isPaused = false;
        FindObjectOfType<GameController>().PauseMenuCanvas.gameObject.SetActive(false);
    }
}
