using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEnemyState : MonoBehaviour
{
    public Enemy enemy;
    public EnemyDisplay enemyDisplay;
    public BattleSystem battleSystem;

    public bool currentlyAlive;
    public int maxHP;
    public int currentHP;
    public int block;
    public int focus = 0;
    public int EnemyAttack = 0;
    public int Burn = 0;
    public int Paralysis = 0;
    public int Poison = 0;
    public int moneyDrop;

    private void Start()
    {
        battleSystem = GameObject.FindWithTag("CombatSystem").GetComponent<BattleSystem>();
        enemyDisplay = GetComponent<EnemyDisplay>();
        currentlyAlive = enemy.currentlyAlive;
        maxHP = enemy.maxHP;
        block = enemy.block;
        currentHP = enemy.currentHP;
        focus = enemy.focus;
        EnemyAttack = enemy.EnemyAttack;
        Burn = enemy.Burn;
        Paralysis = enemy.Paralysis;
        Poison = enemy.Poison;
        moneyDrop = enemy.moneyDrop;
        enemyDisplay.HPSlider.value = 1;
        enemyDisplay.HPValue.text = currentHP.ToString();
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;
        float slidervalue = (float)currentHP / (float)maxHP;
        enemyDisplay.HPSlider.value = slidervalue;
        if (currentHP <= 0)
        {
            enemyDies();
            currentHP = 0;
        }
        enemyDisplay.HPValue.text = currentHP.ToString();
    }

    public void updateStatus() 
    { 
        if (Burn <= 0)
        {
            enemyDisplay.BurnIcon.enabled = false;
            enemyDisplay.Burn.enabled = false;
        }
        else
        {
            enemyDisplay.BurnIcon.enabled = true;
            enemyDisplay.Burn.enabled = true;
            enemyDisplay.Burn.text = Burn.ToString();
        }

        if (Paralysis <= 0)
        {
            enemyDisplay.ParalysisIcon.enabled = false;
            enemyDisplay.Paralysis.enabled = false;
        }
        else
        {
            enemyDisplay.ParalysisIcon.enabled = true;
            enemyDisplay.Paralysis.enabled = true;
            enemyDisplay.Paralysis.text = Paralysis.ToString();
        }

        if (Poison <= 0)
        {
            enemyDisplay.PoisonIcon.enabled = false;
            enemyDisplay.Poison.enabled = false;
        }
        else
        {
            enemyDisplay.PoisonIcon.enabled = true;
            enemyDisplay.Poison.enabled = true;
            enemyDisplay.Poison.text = Poison.ToString();
        }
    }

    public int AffectedbyStatus()
    {
        int damage = 0;

        if (Poison < 0) { Poison = 0; }
        if (Burn < 0) { Burn = 0; }
        if (Paralysis < 0) { Paralysis = 0; }


        if (Poison > 0)
        {
            damage = (Burn + Paralysis + Poison) * 6;
        }
        else
        {
            damage = (Burn + Paralysis + Poison) * 3;
        }
        return damage;
    }

    public void LoseStatus(int statusLoss)
    {
        Burn = Mathf.Max(0, Burn - statusLoss);
        Paralysis = Mathf.Max(0, Paralysis - statusLoss);
        Poison = Mathf.Max(0, Poison - statusLoss);
        enemyDisplay.Burn.text = Burn.ToString();
        enemyDisplay.Paralysis.text = Paralysis.ToString();
        enemyDisplay.Poison.text = Poison.ToString();
        if (Burn == 0)
        {
            enemyDisplay.BurnIcon.enabled = false;
            enemyDisplay.Burn.enabled = false;
        }
        if (Paralysis == 0)
        {
            enemyDisplay.ParalysisIcon.enabled = false;
            enemyDisplay.Paralysis.enabled = false;
        }
        if (Poison == 0)
        {

            enemyDisplay.PoisonIcon.enabled = false;
            enemyDisplay.Poison.enabled = false;
        }
        return;
    }

    public void enemyDies()
    {
        currentlyAlive = false;
        enemyDisplay.TargetIcon.enabled = false;
        enemyDisplay.DeadIcon.enabled = true;
        enemyDisplay.BurnIcon.enabled = false;
        enemyDisplay.ParalysisIcon.enabled = false;
        enemyDisplay.PoisonIcon.enabled = false;
        enemyDisplay.Poison.enabled = false;
        enemyDisplay.Burn.enabled = false;
        enemyDisplay.Paralysis.enabled = false;
        battleSystem.checkIfEnemiesAreAlive();
    }
}
