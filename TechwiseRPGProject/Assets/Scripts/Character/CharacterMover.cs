using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover 
{
    private Character character;
    private Transform transform;
    private Vector2Int currentCell => Game.Map.Grid.GetCell2D(character.gameObject); //reference where character currently is
    private const float TIME_TO_MOVE_ONE_SQUARE = .375f;

    public bool isMoving {get; private set;} = false; 
    public CharacterMover(Character character)
    {

        this.character = character;
        this.transform = character.transform;
    }

    public void TryMove(Vector2Int direction)
    {
        Vector2Int targetCell = currentCell + direction;
        if(isMoving || !direction.IsBasic()){return;}
        if(CanMoveIntoCell(targetCell, direction))
        {
            Game.Map.OccupiedCells.Add((currentCell + direction), character); //adding cell we move to occupied cells. 
            Game.Map.OccupiedCells.Remove(currentCell); //removing old cell
            character.StartCoroutine(Co_Move(direction)); 
        }
    }
    private bool CanMoveIntoCell(Vector2Int targetCell, Vector2Int direction)
    {
    if (IsCellOccupied(targetCell))
        {
            return false;
        }
        Ray2D ray = new Ray2D(Game.Map.Grid.GetCellCenter2D(currentCell), direction);
        RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction);
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 2.0f);

        foreach(RaycastHit2D hit in hits)
        {
            if(hit.distance < Game.Map.Grid.cellSize.x)
            {
                return false;
            }
        }
        return true;
    }

    private bool IsCellOccupied(Vector2Int cell)
    {
        return (Game.Map.OccupiedCells.ContainsKey(cell));
    }

    public IEnumerator Co_Move(Vector2Int direction)
    {
        isMoving=true;
        character.Turn.Turn(direction);  

        Vector2Int startingCell = currentCell;
        Vector2Int endingCell = startingCell+direction;

        Vector2 startingPosition = Game.Map.Grid.GetCellCenter2D(startingCell);
        Vector2 endingPosition = Game.Map.Grid.GetCellCenter2D(endingCell);


        float elapsedTime = 0f;
        while((Vector2)transform.position != endingPosition)
        {
        character.transform.position = Vector2.Lerp(startingPosition, endingPosition, elapsedTime / TIME_TO_MOVE_ONE_SQUARE);
        elapsedTime += Time.deltaTime;
        yield return null;
        }

        transform.position = endingPosition;

        isMoving=false;
    }


}