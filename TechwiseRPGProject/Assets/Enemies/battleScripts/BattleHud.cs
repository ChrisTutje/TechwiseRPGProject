using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
   
public Text nameText;
public Text levelText;
public Slider hpSlider;
public Slider mpSlider;
public Slider staminaSlider;
public Slider expSlider;

public void setHUD(Unit unit) { //variables to put on the HUD
    nameText.text = unit.unitName;
    levelText.text = "Level " + unit.unitLevel; 
    hpSlider.maxValue = unit.maxHp;
    hpSlider.value = unit.currentHp;
    mpSlider.maxValue = unit.maxMp;
    mpSlider.value = unit.currentMp;
    staminaSlider.maxValue = unit.maxStamina;
    staminaSlider.value = unit.currentStamina;
    expSlider.maxValue = 100; //work in progress
    expSlider.value = unit.currentExp;
    
}

public void SetHP(int hp) {
    hpSlider.value = hp;
}

public void SetMP(int mp) {
    mpSlider.value = mp;
}

public void SetStamina(int stamina) {
    staminaSlider.value = stamina;
    staminaSlider.value -= 1;
}

public void SetEXP(int exp) {
    expSlider.value = exp;
}

}
