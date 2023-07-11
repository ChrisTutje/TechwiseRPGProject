using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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
            Vector2Int currentCell = Map.Grid.GetCell2D(this.gameObject);
            transform.position = Map.Grid.GetCellCenter2D(currentCell + Direction.Left); //calling my personal method to get the 2d version of the grid, then going one left.
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector2Int currentCell = Map.Grid.GetCell2D(this.gameObject);
            transform.position = Map.Grid.GetCellCenter2D(currentCell + Direction.Up); //calling my personal method to get the 2d version of the grid, then going one left.
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector2Int currentCell = Map.Grid.GetCell2D(this.gameObject);
            transform.position = Map.Grid.GetCellCenter2D(currentCell + Direction.Down); //calling my personal method to get the 2d version of the grid, then going one left.
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector2Int currentCell = Map.Grid.GetCell2D(this.gameObject);
            transform.position = Map.Grid.GetCellCenter2D(currentCell + Direction.Right); //calling my personal method to get the 2d version of the grid, then going one left.
        }
    }
}
