using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryNPC : Character, IInteractable
{
    //10:31
    [SerializeField] private Interaction interaction;
    public Interaction Interaction => interaction;

    public void Interact()
    {
        Interaction.StartInteraction();

    }

  


}
