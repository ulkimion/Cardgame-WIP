using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHUD : MonoBehaviour
{
    public class BattleHUD : MonoBehaviour
    {
        public Text nameText;
        public Slider hpSlider;
        public Text energyText;

        public void SetEnemyHUD(EnemyAITemplate enemy)
        {
            nameText.text = enemy.unitName;
            hpSlider.maxValue = enemy.maxHP;
            hpSlider.value = enemy.currentHP;
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

}
