using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RetryButton : MonoBehaviour
{
    public Button retry;
    void Start(){
        Button btn = retry.GetComponent<Button>();
		btn.onClick.AddListener(PlayGame);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");
    }

}
