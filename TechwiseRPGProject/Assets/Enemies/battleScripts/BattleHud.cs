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

public Text statusEffectsText; 

private Unit playerUnit;
private Unit enemyUnit;


public void setHUD(Unit unit) { //variables to put on the HUD
    playerUnit = unit;
    enemyUnit = unit;


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

    statusEffectsText.text = SetStatusEffects(playerUnit);
    statusEffectsText.text = SetStatusEffects(enemyUnit);
    
} 


public void SetHP(int hp) {
    hpSlider.value = hp;
    hpTracker.text = hp.ToString();

    statusEffectsText.text = SetStatusEffects(playerUnit);
    statusEffectsText.text = SetStatusEffects(enemyUnit);

    if (!playerUnit.IsExhausted())
        {
            statusEffectsText.text = statusEffectsText.text.Replace("Exhausted\n", "");
        }

        if (!enemyUnit.IsExhausted())
        {
            statusEffectsText.text = statusEffectsText.text.Replace("Exhausted\n", "");
        }
}

public void SetMP(int mp) {
    mpSlider.value = mp;
    mpTracker.text = mp.ToString();
}

public void SetStamina(int stamina) {
    staminaSlider.value = stamina;
    staminaSlider.value -= 1; //used to decrement stamina
    staminaTracker.text = stamina.ToString();
    statusEffectsText.text = SetStatusEffects(playerUnit);
    statusEffectsText.text = SetStatusEffects(enemyUnit);
    
}

public void SetEXP(int exp) {
    expSlider.value = exp;
    expTracker.text = exp.ToString();
}

 public string SetStatusEffects(Unit unit) {
    string statusEffectsText = "";

        if (unit.IsExhausted())
        {
            statusEffectsText += "Exhausted\n";
        } 

        

        if (unit.IsKo())
        {
           statusEffectsText += "KO\n";
        }

        return statusEffectsText;
} 

}
