using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler 
{

    private Player player;
    public InputHandler(Player player) {
        {
            this.player = player;
        }
    }

    // Update is called once per frame
    public void CheckInput()
    {
        KeyCode keyPressed = KeyCode.Escape;

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

        if (keyPressed != KeyCode.Escape)
        {
        HandleInput(keyPressed);
        }
        
        

    }

    public void HandleInput(KeyCode keyPressed)
    {
            switch(keyPressed)
            {
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
        player.Move.Move(direction);
    }
}
