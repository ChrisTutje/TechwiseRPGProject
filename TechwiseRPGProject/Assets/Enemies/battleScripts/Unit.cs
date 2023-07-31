using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour //variable fields for each unit
{
    public string unitName;
    public int unitLevel;
    public int currentExp; 


//HUD stats
    public int maxHp;
    public int currentHp;
    public int maxMp;
    public int currentMp;
    public int maxStamina;
    public int currentStamina;

//totaled stats
    public int attack /*= strength + weaponDamage + strMod*/;
    public int defence /*= armorClass + defMod*/;
    //public int accuracy = perception - armorVision ;
    //public int evasion = agility - armorWeight;
    //public int speed = agility - armorWeight ;
    //public int resistance = luck + lckMod ;
    //public int critical = luck + critMod ; 
    
//base stats
    //[SerializeField]
    //private int strength = 1;

    //[SerializeField]
    //private int perception = 1;

    //[SerializeField]
    //private int endurance = 1;

    //[SerializeField]
    //private int intelligence = 1;

    //[SerializeField]
    //private int agility = 1;

    //[SerializeField]
    //private int luck = 1;

//loot stats
    public int expDrop;

    // ** ACTION MOVES ** //

    public int TakeDamage(int dmg)
    {
        if (dmg <= 0)
            dmg = 1;

        currentHp -= dmg;

        if (currentHp <= 0)
            currentHp = 0;

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
}
