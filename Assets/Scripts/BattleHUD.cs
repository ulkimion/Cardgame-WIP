using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    
    public Text nameText;
    public Slider hpSlider;
    public Text energyText;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
        energyText.text = unit.unitEnergy + "/3";
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }

    public void SetEnergy(int energy)
    {
        energyText.text = energy + "/3";
    }
}
