using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseController : MonoBehaviour
{
    
    public GameObject Canvas;
    private int escape_key_pressed_Count = 0;
    public static bool gameisPaused = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameisPaused = !gameisPaused;
            Canvas.gameObject.SetActive(gameisPaused);
            Pause();
        }


    }
    public void Pause()
    {
        if (gameisPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void Resume()
    {
        gameisPaused = !gameisPaused;
        Pause();
        Canvas.gameObject.SetActive(gameisPaused);
    }
    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
