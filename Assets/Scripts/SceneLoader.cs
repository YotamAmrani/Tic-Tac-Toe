using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene 1");
    }

    public void Menu()
    {
        SceneManager.LoadScene("WelcomeScene");
    }
    public void EndGame()
    {
        Application.Quit();
        Debug.Log("End game");
    }


}
