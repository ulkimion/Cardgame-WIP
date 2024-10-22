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

    public void enemyTurn()
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
        StartCoroutine(BattleSystem.EnemyTurn(enemy.unitName, enemy.DamageInterrupt));
        enemy.focus = enemy.GainFocusInterrupt;

        if (enemy.OnHitInterrupt == true)
        {
            if (BattleSystem.cleanhit())
            {
                BattleSystem.playerUnit.Burn = BattleSystem.playerUnit.Burn + enemy.InfBurnInterrupt;
                BattleSystem.playerUnit.Paralysis = BattleSystem.playerUnit.Paralysis + enemy.InfParalysisInterrupt;
                BattleSystem.playerUnit.Poison = BattleSystem.playerUnit.Poison + enemy.InfPoisonInterrupt;
            }
        }
        else if (enemy.OnHitInterrupt == false)
        {
            BattleSystem.playerUnit.Burn = BattleSystem.playerUnit.Burn + enemy.InfBurnInterrupt;
            BattleSystem.playerUnit.Paralysis = BattleSystem.playerUnit.Paralysis + enemy.InfParalysisInterrupt;
            BattleSystem.playerUnit.Poison = BattleSystem.playerUnit.Poison + enemy.InfPoisonInterrupt;
        }

        enemy.CurrentStep = 1;
    }

    public void turn1()
    {
        StartCoroutine(BattleSystem.EnemyTurn(enemy.unitName, enemy.Damage1));
        enemy.focus = enemy.GainFocus1;

        if (enemy.OnHit1 == true)
            {
            if (BattleSystem.cleanhit()) 
                {
                BattleSystem.playerUnit.Burn = BattleSystem.playerUnit.Burn + enemy.InfBurn1;
                BattleSystem.playerUnit.Paralysis = BattleSystem.playerUnit.Paralysis + enemy.InfParalysis1;
                BattleSystem.playerUnit.Poison = BattleSystem.playerUnit.Poison + enemy.InfPoison1;
                }
            }
        else if (enemy.OnHit1 == false)
            {
            BattleSystem.playerUnit.Burn = BattleSystem.playerUnit.Burn + enemy.InfBurn1;
            BattleSystem.playerUnit.Paralysis = BattleSystem.playerUnit.Paralysis + enemy.InfParalysis1;
            BattleSystem.playerUnit.Poison = BattleSystem.playerUnit.Poison + enemy.InfPoison1;
            }



        if (enemy.NumberOfSteps > 1 ) 
        { 
            enemy.CurrentStep = 2;
        }

    }

    public void turn2()
    {
        StartCoroutine(BattleSystem.EnemyTurn(enemy.unitName, enemy.Damage2));
        enemy.focus = enemy.GainFocus2;

        if (enemy.OnHit2 == true)
        {
            if (BattleSystem.cleanhit())
            {
                BattleSystem.playerUnit.Burn = BattleSystem.playerUnit.Burn + enemy.InfBurn2;
                BattleSystem.playerUnit.Paralysis = BattleSystem.playerUnit.Paralysis + enemy.InfParalysis2;
                BattleSystem.playerUnit.Poison = BattleSystem.playerUnit.Poison + enemy.InfPoison2;
            }
        }
        else if (enemy.OnHit2 == false)
        {
            BattleSystem.playerUnit.Burn = BattleSystem.playerUnit.Burn + enemy.InfBurn2;
            BattleSystem.playerUnit.Paralysis = BattleSystem.playerUnit.Paralysis + enemy.InfParalysis2;
            BattleSystem.playerUnit.Poison = BattleSystem.playerUnit.Poison + enemy.InfPoison2;
        }

        if (enemy.NumberOfSteps > 2)
        {
            enemy.CurrentStep = 3;
        }
        else
        {
            enemy.CurrentStep = 1;
        }
    }

    public void turn3()
    {
        StartCoroutine(BattleSystem.EnemyTurn(enemy.unitName, enemy.Damage3));
        enemy.focus = enemy.GainFocus3;

        if (enemy.OnHit3 == true)
        {
            if (BattleSystem.cleanhit())
            {
                BattleSystem.playerUnit.Burn = BattleSystem.playerUnit.Burn + enemy.InfBurn3;
                BattleSystem.playerUnit.Paralysis = BattleSystem.playerUnit.Paralysis + enemy.InfParalysis3;
                BattleSystem.playerUnit.Poison = BattleSystem.playerUnit.Poison + enemy.InfPoison3;
            }
        }
        else if (enemy.OnHit1 == false)
        {
            BattleSystem.playerUnit.Burn = BattleSystem.playerUnit.Burn + enemy.InfBurn3;
            BattleSystem.playerUnit.Paralysis = BattleSystem.playerUnit.Paralysis + enemy.InfParalysis3;
            BattleSystem.playerUnit.Poison = BattleSystem.playerUnit.Poison + enemy.InfPoison3;
        }

        enemy.CurrentStep = 1;
    }

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
    }
}
