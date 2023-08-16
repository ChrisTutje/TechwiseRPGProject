using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputHandler 
{
    PauseMenu pm;
    private Player player;
    public InputHandler(Player player, PauseMenu pauseMenu) {
        {
            this.player = player;
            this.pm = pauseMenu;
        }
    }

    // Update is called once per frame
    public void CheckInput()
    {
        KeyCode keyPressed = KeyCode.P;

        if (Input.GetKeyDown(KeyCode.A))
        {
            keyPressed = KeyCode.A;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            keyPressed = KeyCode.W;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            keyPressed = KeyCode.D;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            keyPressed = KeyCode.S;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            keyPressed = KeyCode.Escape;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            keyPressed = KeyCode.E; 
            
        }

        if (keyPressed != KeyCode.P)
        {
        HandleInput(keyPressed);
        }

        
        

    }

    public void HandleInput(KeyCode keyPressed)
    {
            switch(keyPressed)
            {
                case(KeyCode.E):
                    ProcessInteract();
                    break;
                case(KeyCode.Escape):
                    pm.PMRunner();
                    break;

                case(KeyCode.A):
                case(KeyCode.W):
                case(KeyCode.D):
                case(KeyCode.S):
                    ProcessMovementInput(keyPressed);
                    break;  
                
                
            }
    }
    private void ProcessMovementInput(KeyCode keyPressed)
    {
        if(player.isMoving==true)
        {
            return;
        }
        Vector2Int direction = new Vector2Int(0,0);
        switch(keyPressed)
        {
            case(KeyCode.A):
                direction = Direction.Left;
                break;
            case(KeyCode.W):
                direction = Direction.Up;
                break;
            case(KeyCode.D):
                direction = Direction.Right;
                break;
            case(KeyCode.S):
                direction = Direction.Down;
                break;

        }
        player.Move.TryMove(direction);
    }

    private void ProcessInteract()
    {
        Vector2Int cellToCheck = player.Facing + Game.Map.Grid.GetCell2D(player.gameObject);
        
        if (!Game.Map.OccupiedCells.ContainsKey(cellToCheck))
        {
            return;

        }
        if ((Game.Map.OccupiedCells[cellToCheck]) is IInteractable interactable)
        {
            interactable.Interact();
        }
    }
}
