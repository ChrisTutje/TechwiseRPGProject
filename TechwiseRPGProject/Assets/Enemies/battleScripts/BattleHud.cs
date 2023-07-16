using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
   
public Text nameText;
public Text levelText;
public Slider hpSlider;

public void setHUD(Unit unit) { //variables to put on the HUD
    nameText.text = unit.unitName;
    //levelText.text = "lvl1 " + unit.unitLevel; //superfluous stat
    hpSlider.maxValue = unit.maxHp;
    hpSlider.value = unit.currentHp;
}

public void SetHP(int hp) {
    hpSlider.value = hp;
}

}
