using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour //variable fields for each unit
{
    public string unitName;
    public int unitLevel;
    //public int exp; 

    public int maxHp;
    public int currentHp;
    public int maxMp;
    public int currentMp;
    public int maxStamina;
    public int currentStamina;

    public int attack;
    //public int defence;
    //public int accuracy;
    //public int evasion;
    //public int speed;
    //public int resistance;
    //public int critical; 
    
    //public int strength;
    //public int perception;
    //public int endurance;
    //public int charisma;
    //public int intellegence;
    //public int agility;
    //public int luck; 


    public bool TakeDamage(int dmg) {
        currentHp -= dmg;

        if(currentHp <= 0)
            return true;
        else
            return false;


    }
    
}
