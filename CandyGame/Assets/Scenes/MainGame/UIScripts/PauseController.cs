using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseController : MonoBehaviour
{
    //// Start is called before the first frame update

    //// Update is called once per frame
    //int escape_Button_Pressed_Count = 0;
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        PauseScreen();
    //    }
    //}

    //private void PauseScreen()
    //{
    //    Time.timeScale = 0;

    //    escape_Button_Pressed_Count += 1;
    //    if (escape_Button_Pressed_Count % 2 == 0)
    //    {
    //        Resume();
    //    }
    //}
    //private void Resume()
    //{
    //    Time.timeScale = 1;

    //    escape_Button_Pressed_Count = 0;
    //}
    //private void Quit()
    //{

    //}
    //private void Settings()
    //{

    //}
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
        Time.timeScale = 1;
    }
    public void Quit()
    {

    }
    public void Settings()
    {

    }



}
