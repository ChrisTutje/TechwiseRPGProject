using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover 
{
    private Character character;
    private Transform transform;
    private const float TIME_TO_MOVE_ONE_SQUARE = .375f;

    public bool isMoving {get; private set;}
    public CharacterMover(Character character)
    {

        this.character = character;
        this.transform = character.transform;
    }

    public void Move(Vector2Int direction)
    {
    if (direction.IsBasic() || isMoving==false)
        {
            character.StartCoroutine(Co_Move(direction)); 
        }

    }

    public IEnumerator Co_Move(Vector2Int direction)
    {
        isMoving=true;
        Vector2Int startingCell = Map.Grid.GetCell2D(character.gameObject);
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
        isMoving=false;
    }


}
