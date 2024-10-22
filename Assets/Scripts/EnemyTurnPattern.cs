using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTurnPattern : MonoBehaviour
{
    public int enemyId;
    public Enemy enemy;
    public BattleSystem BattleSystem;

    public void Start()
    {
        BattleSystem = GameObject.FindWithTag("CombatSystem").GetComponent<BattleSystem>();
    }

    public void enemyTurn ()
    {
        if (enemy.Interrupt == Interrupt.Paralysis && BattleSystem.playerUnit.Paralysis > 0) 
        {
            interruptionTurn();
        }
        else if (enemy.Interrupt == Interrupt.Burn && BattleSystem.playerUnit.Burn > 0)
        {
            interruptionTurn();
        }
        else if (enemy.Interrupt == Interrupt.Poison && BattleSystem.playerUnit.Poison > 0)
        {
            interruptionTurn();
        }
        else if (enemy.CurrentStep == 1)
        {
            turn1();
        }
        else if (enemy.CurrentStep == 2)
        {
            turn2();
        }
        else if (enemy.CurrentStep == 3)
        {
            turn3();
        }

    }

    public void interruptionTurn() 
    {
        BattleSystem.playerUnit.currentHP = BattleSystem.playerUnit.currentHP - 1;
    }

    public void turn1()
    {
        BattleSystem.playerUnit.Burn = BattleSystem.playerUnit.Burn + enemy.InfBurn1;
        BattleSystem.playerUnit.Paralysis = BattleSystem.playerUnit.Paralysis + enemy.InfParalysis1;
        BattleSystem.playerUnit.Poison = BattleSystem.playerUnit.Poison + enemy.InfPoison1;

    }

    public void turn2()
    {
        BattleSystem.playerUnit.currentHP = BattleSystem.playerUnit.currentHP - 1;
    }

    public void turn3()
    {
        BattleSystem.playerUnit.currentHP = BattleSystem.playerUnit.currentHP - 1;
    }

    /*
    public bool TakeDamage(int dmg)
    {
        enemy.currentHP -= dmg;
        //HpBar.UpdateHPBar(currentHP,maxHP);
        if (enemy.currentHP <= 0)
            return true;
        else
            return false;

    }
    public int AffectedbyStatus()
    {
        int damage = (enemy.Burn + enemy.Paralysis + enemy.Poison);
        LoseStatus(1);
        return damage;
    }

    public void LoseStatus(int statusLoss)
    {
        enemy.Burn = Mathf.Max(0, enemy.Burn - statusLoss);
        enemy.Paralysis = Mathf.Max(0, enemy.Paralysis - statusLoss);
        enemy.Poison = Mathf.Max(0, enemy.Poison - statusLoss);
        return;
    }

    public void enemyDies()
    {
        enemy.currentlyAlive = false;
    }*/
}
