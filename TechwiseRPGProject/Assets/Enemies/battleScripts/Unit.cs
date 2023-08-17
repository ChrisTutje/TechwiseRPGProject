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

    [SerializeField]
    public int endurance = 1;

    [SerializeField]
   public int intelligence = 1;



//loot stats
    public int expDrop;

//totaled stats
    [HideInInspector]
    public int attack ;
    [HideInInspector]
    public int defence;
  

    //equipment stats
    public Weapon equippedWeapon;
    public Armor equippedArmor;

    //Middle-man code
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

        attack = strength  + equippedWeapon.weaponAttack ; 
        defence = 1  + equippedArmor.armorClass ; 

    }


    // ** ACTION MOVES ** //

    public int TakeDamage(int dmg) //used to calculate damage. Attacks must do at least 1 damage, and HP can't be negative (yet). 
    {
        if (dmg <= 0)
            dmg = 1;

        currentHp -= dmg;

        if (currentHp < 0)
            currentHp = 0; 

        return dmg;
    }

    
    public void Heal(int amount){ //used to restore current HP, Current HP can't exceed maximum HP (yet)
        currentHp += amount;
        if (currentHp > maxHp)
            currentHp = maxHp;
    }

     public void Block(){
    }

    public void DrainStamina(int amount) //used to drain stamina, stamina can't be negative
    {
        currentStamina -= amount;
        if (currentStamina < 0)
            currentStamina = 0;
    }

      public void RestoreStamina(int amount) //used to restore stamina, current stamina can't exceed max stamina
    {
        currentStamina += amount;
        if (currentStamina >= maxStamina)
            currentStamina = maxStamina;
    }

    public void DeductMP(int amount) //deduct MP, MP can't be negative
{
    currentMp -= amount;
    if (currentMp < 0)
        currentMp = 0;
}

    //** STATUS EFFECTS ** // 
    

       public bool IsKo() //a unit with no HP is K.O, K.O'd unit's can't fight 
    {
        return currentHp <= 0;
    }


     public bool IsExhausted() //A unit with no stamina is exhausted, exhausted units can't use melee attacks 
    {
        return currentStamina <= 0;
    } 
  
}
