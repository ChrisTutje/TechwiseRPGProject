using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    private InputHandler InputHandler;
    public PauseMenu pm {get; private set;}


    protected override void Awake() {
        base.Awake();
        pm = FindObjectOfType<Character>().pauseMenu;
        InputHandler = new InputHandler(this, pm);
    }

    void Start()
    {
        base.Start();
        
    }

    protected override void Update()
    {
        base.Update();
        InputHandler.CheckInput();
    }
}
