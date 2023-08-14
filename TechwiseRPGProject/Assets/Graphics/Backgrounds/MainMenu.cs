using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Forest Scene");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT)");
        Application.Quit();
    }
}
