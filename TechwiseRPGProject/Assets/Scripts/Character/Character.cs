using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public CharacterMover Move {get; private set;}
    public PauseMenu pauseMenu;



    
    public bool isMoving => Move.isMoving;

    protected virtual void Awake() {
        {
            Move = new CharacterMover(this);
        }
    }
    protected virtual void Start()
    {
        Vector2Int currentCell = Map.Grid.GetCell2D(this.gameObject); //calling personal method made in GridExtensions
        transform.position = Map.Grid.GetCellCenter2D(currentCell);        //moved this to character for other sprites that we add to snap into a grid spot as well
        
    }
    protected virtual void Update()
    {
        
    }
}
