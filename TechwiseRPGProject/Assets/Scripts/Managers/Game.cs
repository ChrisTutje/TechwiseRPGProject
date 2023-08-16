using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    World,
    Cutscene,
    Battle,
    Menu,
}

public class Game : MonoBehaviour
{
   public static GameState State {get; private set;}
    public static Map Map {get; private set;}
    public static Player Player {get; private set; }
    public  Grid Grid {get;private set;} //making a script just to pull the grid- so i dont have to do this same 4 lines of code in every script.

    [SerializeField] private Map startingMap;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private  Vector2Int startingCell;


        private void Awake()
        {
        if (Map== null)
            {
                Map = Instantiate(startingMap);
            }
        if (Player==null)
        {
            GameObject gameObject = Instantiate(playerPrefab, Map.Grid.GetCellCenter2D(startingCell), Quaternion.identity);
            Player= gameObject.GetComponent<Player>();
        }


        }   
        
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.B))
            {
                //StartBattle();
            }

            if(Input.GetKeyDown(KeyCode.E))
            {
                //EndBattle()
            }
        }

}



