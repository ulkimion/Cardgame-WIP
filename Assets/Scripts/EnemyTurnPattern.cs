using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTurnPattern : MonoBehaviour
{
    public int enemyId;
    public Enemy enemy;
    public CombatEnemyState combatEnemyState;
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
        combatEnemyState.focus = enemy.GainFocusInterrupt;
        combatEnemyState.block = enemy.BlockInterrupt;

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
        Debug.Log("Turno 1");
        StartCoroutine(BattleSystem.EnemyTurn(enemy.unitName, enemy.Damage1));
        combatEnemyState.focus = enemy.GainFocus1;
        combatEnemyState.block = enemy.Block1;

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
        combatEnemyState.focus = enemy.GainFocus2;
        combatEnemyState.block = enemy.Block2;

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
        combatEnemyState.focus = enemy.GainFocus3;
        combatEnemyState.block = enemy.Block3;

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
}
