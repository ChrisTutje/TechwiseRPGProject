using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetAciveScene().buildIndex * 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
