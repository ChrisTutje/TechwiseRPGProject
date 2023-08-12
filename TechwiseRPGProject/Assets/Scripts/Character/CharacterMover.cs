using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover 
{
    private Character character;
    private Transform transform;
    private Vector2Int currentCell => Map.Grid.GetCell2D(character.gameObject); //reference where character currently is
    private const float TIME_TO_MOVE_ONE_SQUARE = .375f;

    public bool isMoving {get; private set;} = false; 
    public CharacterMover(Character character)
    {

        this.character = character;
        this.transform = character.transform;
    }

    public void TryMove(Vector2Int direction)
    {
        if(isMoving)
        {
            return;
        }


        Vector2Int targetCell = currentCell + direction;


    if (direction.IsBasic() && IsCellEmpty(targetCell))
        {
            
        Map.OccupiedCells.Add((currentCell + direction), character); //adding cell we move to occupied cells. 
        Map.OccupiedCells.Remove(currentCell); //removing old cell
            character.StartCoroutine(Co_Move(direction)); 
        }

    }

    private bool IsCellEmpty(Vector2Int cell)
    {
        return !(Map.OccupiedCells.ContainsKey(cell));
    }

    public IEnumerator Co_Move(Vector2Int direction)
    {
        isMoving=true;
        character.Turn.Turn(direction);  

        Vector2Int startingCell = currentCell;
        Vector2Int endingCell = startingCell+direction;

        Vector2 startingPosition = Map.Grid.GetCellCenter2D(startingCell);
        Vector2 endingPosition = Map.Grid.GetCellCenter2D(endingCell);


        float elapsedTime = 0f;
        while((Vector2)transform.position != endingPosition)
        {
        character.transform.position = Vector2.Lerp(startingPosition, endingPosition, elapsedTime / TIME_TO_MOVE_ONE_SQUARE);
        elapsedTime += Time.deltaTime;
        yield return null;
        }

        transform.position = endingPosition;
        character.game.SwitchToSpecificScene();

        isMoving=false;
    }


}