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

    public static DialogueWindow dialogueWindow{get; private set;}
    public  Grid Grid {get;private set;} //making a script just to pull the grid- so i dont have to do this same 4 lines of code in every script.

    [SerializeField] private Map startingMap;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private  Vector2Int startingCell;
    [SerializeField] private GameObject cameraPrefab;


        private void Awake()
        {
            dialogueWindow = FindObjectOfType<DialogueWindow>();
        if (Map== null)
            {
                Map = Instantiate(startingMap);
            }
        if (Player==null)
        {
            GameObject gameObject = Instantiate(playerPrefab, Map.Grid.GetCellCenter2D(startingCell), Quaternion.identity);
            Player= gameObject.GetComponent<Player>();


        }
         if (Camera.main == null && cameraPrefab != null)
        {
            GameObject cameraObject = Instantiate(cameraPrefab);
        CameraFollow cameraFollow = cameraObject.GetComponent<CameraFollow>();
        if (cameraFollow != null)
        {
            cameraFollow.target = Player.transform;
        }
        }
            DontDestroyOnLoad(this);
            DontDestroyOnLoad(Player);
        }

          
        
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.B))
            {
                StartBattle();
            }
             if(Input.GetKeyDown(KeyCode.N))
            {
                StartBossBattle();
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                EndBattle();
            }
            if(Input.GetKeyDown(KeyCode.C))
            {
                RollCredits();
            }
            
        }
        public static void StartDialogue(DialogueScene sceneToPlay)
                {
                    State = GameState.Cutscene;
                    dialogueWindow.Open(sceneToPlay);
                }
    public static void EndDialogue()
    {
        State = GameState.World;
    }
        private void StartBattle()
        {
            SceneManager.LoadScene("BattleScene");
        }
        private void StartBossBattle()
        {
            SceneManager.LoadScene("FelipeBossBattle");
        }
        private void EndBattle()
        {
            SceneManager.LoadScene("MainGame");
        }
        private void RollCredits()
        {
            SceneManager.LoadScene("Credits");
        }


}



