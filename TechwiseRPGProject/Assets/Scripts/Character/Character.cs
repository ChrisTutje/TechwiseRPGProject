using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]


public abstract class Character : MonoBehaviour
{
    public CharacterMover Move {get; private set;}
    public CharacterTurner Turn {get; private set;}
    public CharacterAnimator Animator{get; private set;}
    public Game game{get; private set;}


    public PauseMenu pauseMenu;



    
    public bool isMoving => Move.isMoving;


    public Vector2Int Facing => Turn.Facing;

    protected virtual void Awake() {
        {
            Move = new CharacterMover(this);
            Turn = new CharacterTurner();
            Animator = new CharacterAnimator(this);
            game = new Game(this);

        }
    }
    protected virtual void Start()
    {
        Vector2Int currentCell = Map.Grid.GetCell2D(this.gameObject); //calling personal method made in GridExtensions
        transform.position = Map.Grid.GetCellCenter2D(currentCell);        //moved this to character for other sprites that we add to snap into a grid spot as well
        
    }
    protected virtual void Update()
    {
        
        Animator.ChooseLayer();
        Animator.UpdateParamaters();
        
    }
}
