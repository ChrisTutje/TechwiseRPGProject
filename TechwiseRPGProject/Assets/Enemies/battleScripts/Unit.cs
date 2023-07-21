using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour //variable fields for each unit
{
    public string unitName;
    public int unitLevel;
    public int currentExp; 


//resource stats
    public int maxHp;
    public int currentHp;
    public int maxMp;
    public int currentMp;
    public int maxStamina;
    public int currentStamina;

//totaled stats
    public int attack /*= strength + weaponDamage + strMod*/;
    //public int defence = armorClass + defMod;
    //public int accuracy = perception - armorVision ;
    //public int evasion = agility - armorWeight;
    //public int speed = agility - armorWeight ;
    //public int resistance = luck + lckMod ;
    //public int critical = luck + critMod ; 
    
//base stats
    public int strength;
    public int perception;
    public int endurance;
    public int intellegence;
    public int agility;
    public int luck; 

//loot stats
    public int expDrop;




    public bool TakeDamage(int dmg) {
        if (dmg <= 0)
            dmg = 1;

        currentHp -= dmg;

        if(currentHp <= 0)
            return true;
        else
            return false;


    }
    
}
