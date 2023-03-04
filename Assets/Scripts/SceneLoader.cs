using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
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
