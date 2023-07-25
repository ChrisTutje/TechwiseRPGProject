using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
   
public Text nameText;
public Text levelText;

public Slider hpSlider;
public Text hpTracker;

public Slider mpSlider;
public Text mpTracker;

public Slider staminaSlider;
public Text staminaTracker;

public Slider expSlider;
public Text expTracker;

public void setHUD(Unit unit) { //variables to put on the HUD
    nameText.text = unit.unitName;
    levelText.text = "Level " + unit.unitLevel; 

    hpTracker.text = unit.currentHp.ToString();
    hpSlider.maxValue = unit.maxHp;
    hpSlider.value = unit.currentHp;

    mpTracker.text = unit.currentMp.ToString();
    mpSlider.maxValue = unit.maxMp;
    mpSlider.value = unit.currentMp;

    staminaTracker.text = unit.currentStamina.ToString();
    staminaSlider.maxValue = unit.maxStamina;
    staminaSlider.value = unit.currentStamina;

    expSlider.maxValue = 100; //work in progress
    expSlider.value = unit.currentExp;
    expTracker.text = unit.currentExp.ToString();
    
}

public void SetHP(int hp) {
    hpSlider.value = hp;
    hpTracker.text = hp.ToString();
}

public void SetMP(int mp) {
    mpSlider.value = mp;
    mpTracker.text = mp.ToString();
}

public void SetStamina(int stamina) {
    staminaSlider.value = stamina;
    staminaSlider.value -= 1;
    staminaTracker.text = stamina.ToString();
}

public void SetEXP(int exp) {
    expSlider.value = exp;
    expTracker.text = exp.ToString();
}

}
