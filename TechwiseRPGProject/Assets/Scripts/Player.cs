using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

 
    // Start is called before the first frame update
    void Start()
    {
        Vector2Int currentCell = Map.Grid.GetCell2D(this.gameObject); //calling personal method made in GridExtensions
        transform.position = Map.Grid.GetCellCenter2D(currentCell);        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Move.Move(Direction.Left);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Move.Move(Direction.Up);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Move.Move(Direction.Down); 
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Move.Move(Direction.Right);
        }
    }
}
