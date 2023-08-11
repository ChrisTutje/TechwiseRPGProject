using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Game  
{
    public Character character;
    public Vector2 playerPosition;
    
    public Game(Character character)
    {
        this.character = character;
    }



   public void SwitchToSpecificScene()
    {
        float probability = .05f; // 10% chance
        if (SceneManager.GetSceneByName("PlayerMovementtester").isLoaded)
        {
        if (Random.value < probability)
        {
            SceneManager.LoadScene("BattleScene");
        }
        }
        else if (SceneManager.GetSceneByName("BattleScene").isLoaded)
        {
            SceneManager.LoadScene("PlayerMovementtester");
        }
    }

    public void SavePlayerPosition()
    {

    }



}


