using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    public InputHandler InputHandler {get; private set;}
    public PauseMenu pm {get; private set;}


    protected override void Awake() {
        base.Awake();
        InputHandler = new InputHandler(this, pm);
    }

    void Start()
    {
        base.Start();
        Vector2Int currentCell = Map.Grid.GetCell2D(this.gameObject); //calling personal method made in GridExtensions
        transform.position = Map.Grid.GetCellCenter2D(currentCell);        
    }

    protected override void Update()
    {
        base.Update();
        InputHandler.CheckInput();
    }
}
