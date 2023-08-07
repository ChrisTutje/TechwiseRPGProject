using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game 
{
    public Character character;


    public Game(Character character)
    {
        this.character = character;
    }



   public void SwitchToSpecificScene()
    {
        float probability = 0.05f; // 10% chance

        if (Random.value < probability)
        {
            SceneManager.LoadScene("BattleScene");
        }
    }



}



