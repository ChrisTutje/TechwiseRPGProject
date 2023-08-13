using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnToTitle : MonoBehaviour
{
    public string mainSceneName = "MainScene";
    public Button quitToTitleButton;

    void Start()
    {
        quitToTitleButton.onClick.AddListener(QuitToTitle);
    }

    void QuitToTitle()
    {
        SceneManager.LoadScene(mainSceneName);
    }
}
