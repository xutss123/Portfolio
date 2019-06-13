using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static float startingTime;
    public void PlayGame()
    {
        SceneManager.LoadScene("Challenge1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ChooseEasy()
    {
        startingTime = 60f;
    }
    public void ChooseMedium()
    {
        startingTime = 45f;
    }
    public void ChooseHard()
    {
        startingTime = 30f;
    }
}
