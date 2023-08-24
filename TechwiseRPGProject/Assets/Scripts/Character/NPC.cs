using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character, IInteractable
{
  

    [SerializeField] private ScriptableObject interaction;
    public ScriptableObject Interaction => interaction;

    public void Interact()
    {
        if(interaction is DialogueScene scene)
        {
            Vector2Int currentFacing = Facing;
            Game.StartDialogue(scene);
        }
    }

    protected override void Update()
    {
       
    }

  
}