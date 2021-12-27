using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    //go to the first game scene.
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }
    //settings scene
    public void Settings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }
    //exit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
