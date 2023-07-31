using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator 
{
   private Character character;
   private Animator animator;

   

   private string horizontalParameter = "xDir";
   private string verticalParamater = "yDir";

   public CharacterAnimator(Character character)
   {
    this.character = character;
    this.animator = character.GetComponent<Animator>();

   }

   public void ChooseLayer()
   {

   }
}
