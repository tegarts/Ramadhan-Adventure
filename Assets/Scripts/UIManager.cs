using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
[SerializeField] public GameObject gameOverScreen;
[SerializeField] public GameObject pausedScreen;
[SerializeField] private AudioClip gameOverSound;

    private void Awake() {
        gameOverScreen.SetActive(false);
        pausedScreen.SetActive(false);
    }
    // Start is called before the first frame update
    #region Game Over Functions
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        AudioManager.instance.PlaySound(gameOverSound);
    }

     public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

     public void RestartPaused()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    //Activate game over screen
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Paused()
    {
        Time.timeScale = 0;
        pausedScreen.SetActive(true);
        
    }

    public void Continue()
    {
        Time.timeScale = 1;
        pausedScreen.SetActive(false);
    }

    //Quit game/exit play mode if in Editor
    // public void Quit()
    // {
    //     Application.Quit(); //Quits the game (only works in build)

    //     #if UNITY_EDITOR
    //     UnityEditor.EditorApplication.isPlaying = false; //Exits play mode
    //     #endif
    // }


    #endregion
}
