using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour //variable fields for each unit
{
    public string unitName;
    public int unitLevel;
    public int currentExp; 


//HUD stats
    [HideInInspector]
    public int maxHp;
    [HideInInspector]
    public int currentHp;

    [HideInInspector]
    public int maxMp;
    [HideInInspector]
    public int currentMp;

    [HideInInspector]
    public int maxStamina;
    [HideInInspector]
    public int currentStamina;
    
//base stats
    [SerializeField]
    public int strength = 1;

    //[SerializeField]
    //private int perception = 1;

    [SerializeField]
    public int endurance = 1;

    [SerializeField]
   public int intelligence = 1;

    //[SerializeField]
    //private int agility = 1;

    //[SerializeField]
    //private int luck = 1;

//loot stats
    public int expDrop;

//totaled stats
    [HideInInspector]
    public int attack /*= strength + weaponDamage + strMod*/;
    [HideInInspector]
    public int defence/*= armorClass + defMod*/;
    //public int accuracy = perception - armorVision ;
    //public int evasion = agility - armorWeight;
    //public int speed = agility - armorWeight ;
    //public int resistance = luck + lckMod ;
    //public int critical = luck + critMod ; 


    //Middle-man code, very janky
    private void Start()
    {
        CalculateStats();
         
    }

    private void CalculateStats()
    {
        maxHp = endurance * 4;
        currentHp = maxHp;

        maxMp = intelligence * 3; 
        currentMp = maxMp;

        maxStamina = endurance * 2; 
        currentStamina = maxStamina;

        attack = strength; 
        defence = 1; 

    }


    // ** ACTION MOVES ** //

    public int TakeDamage(int dmg)
    {
        if (dmg <= 0)
            dmg = 1;

        currentHp -= dmg;

        if (currentHp < 0)
            currentHp = 0; //prevents HP from falling below 0

        return dmg;
    }

    
    public void Heal(int amount){
        currentHp += amount;
        if (currentHp > maxHp)
            currentHp = maxHp;
    }

     public void Block(){
       // playerUnit.defence *= 2;
    }

    public void DrainStamina(int amount)
    {
        currentStamina -= amount;
        if (currentStamina < 0)
            currentStamina = 0;
    }

      public void RestoreStamina(int amount)
    {
        currentStamina += amount;
        if (currentStamina >= maxStamina)
            currentStamina = maxStamina;
    }

    //** STATUS EFFECTS ** // 
    

       public bool IsKo()
    {
        return currentHp <= 0;
    }

    /* public bool IsDead() //Idea for a mechanic, not implemented
    {
        return currentHp <= -maxHP ;
    } */

     public bool IsExhausted()
    {
        return currentStamina <= 0;
    } 
}
