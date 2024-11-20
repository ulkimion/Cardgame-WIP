using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTurnPattern : MonoBehaviour
{
    public int enemyId;
    public Enemy enemy;
    public CombatEnemyState combatEnemyState;
    public BattleSystem BattleSystem;
    public EnemyDisplay EnemyDisplay;

    public void Start()
    {
        BattleSystem = GameObject.FindWithTag("CombatSystem").GetComponent<BattleSystem>();
    }

    public void enemyTurn(string step)
    {
        if (enemy.Interrupt == Interrupt.Paralysis && BattleSystem.playerUnit.Paralysis > 0) 
        {
            interruptionTurn(step);
        }
        else if (enemy.Interrupt == Interrupt.Burn && BattleSystem.playerUnit.Burn > 0)
        {
            interruptionTurn(step);
        }
        else if (enemy.Interrupt == Interrupt.Poison && BattleSystem.playerUnit.Poison > 0)
        {
            interruptionTurn(step);
        }
        else if (enemy.CurrentStep == 1)
        {
            turn1(step);
        }
        else if (enemy.CurrentStep == 2)
        {
            turn2(step);
        }
        else if (enemy.CurrentStep == 3)
        {
            turn3(step);
        }

    }

    public void interruptionTurn(string step)
    {
        if (step == "turnStart") 
        {
            updateSymbol("turnInterrupt");
        }
        else {
            if (combatEnemyState.Paralysis > 0)
            {
                int DamageUnderParalysis = (int)(enemy.DamageInterrupt * 0.75);
                StartCoroutine(BattleSystem.EnemyTurn(enemy.unitName, DamageUnderParalysis));
            }
            else
            {
                StartCoroutine(BattleSystem.EnemyTurn(enemy.unitName, enemy.DamageInterrupt));
            }

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
    }

    public void turn1(string step)
    {
        if (step == "turnStart")
        {
            updateSymbol("turn1");
        }
        else
        {
            if (combatEnemyState.Paralysis > 0)
            {
                int DamageUnderParalysis = (int)(enemy.Damage1 * 0.75);
                StartCoroutine(BattleSystem.EnemyTurn(enemy.unitName, DamageUnderParalysis));
            }
            else
            {
                StartCoroutine(BattleSystem.EnemyTurn(enemy.unitName, enemy.Damage1));
            }
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



            if (enemy.NumberOfSteps > 1)
            {
                enemy.CurrentStep = 2;
            }

        }
    }

    public void turn2(string step)
    {
        if (step == "turnStart")
        {
            updateSymbol("turn2");
        }
        else
        {
            if (combatEnemyState.Paralysis > 0)
            {
                int DamageUnderParalysis = (int)(enemy.Damage2 * 0.75);
                StartCoroutine(BattleSystem.EnemyTurn(enemy.unitName, DamageUnderParalysis));
            }
            else
            {
                StartCoroutine(BattleSystem.EnemyTurn(enemy.unitName, enemy.Damage2));
            }
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
    }

    public void turn3(string step)
    {
        if (step == "turnStart")
        {
            updateSymbol("turn3");
        }
        else
        {
            if (combatEnemyState.Paralysis > 0)
            {
                int DamageUnderParalysis = (int)(enemy.Damage3 * 0.75);
                StartCoroutine(BattleSystem.EnemyTurn(enemy.unitName, DamageUnderParalysis));
            }
            else
            {
                StartCoroutine(BattleSystem.EnemyTurn(enemy.unitName, enemy.Damage3));
            }
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

    private void updateSymbol(string turn)
    {
        UnityEngine.Debug.Log("Se llego aqui");
        EnemyDisplay.Waiting.enabled = false;
        EnemyDisplay.Attack.enabled = false;
        EnemyDisplay.AttackValue.enabled = false;
        EnemyDisplay.Attack_Debuff.enabled = false;
        EnemyDisplay.Debuff.enabled = false;

        if(turn == "turn1") 
            {
                if(enemy.ActionStep1 == Action.Waiting)
                {
                    EnemyDisplay.Waiting.enabled = true;
                }
                else if (enemy.ActionStep1 == Action.Attack)
                {
                    EnemyDisplay.Attack.enabled = true;
                    EnemyDisplay.AttackValue.enabled = true;
                    EnemyDisplay.AttackValue.text = enemy.Damage1.ToString();
                }
                else if (enemy.ActionStep1 == Action.Attack_Debuff)
                {
                    EnemyDisplay.Attack_Debuff.enabled = true;
                    EnemyDisplay.AttackValue.enabled = true;
                    EnemyDisplay.AttackValue.text = enemy.Damage1.ToString();
                }
                else if (enemy.ActionStep1 == Action.Debuff)
                {
                    EnemyDisplay.Debuff.enabled = true;
                }
                return;
            }
        else if (turn == "turn2")
        {
            if (enemy.ActionStep2 == Action.Waiting)
            {
                EnemyDisplay.Waiting.enabled = true;
            }
            else if (enemy.ActionStep2 == Action.Attack)
            {
                EnemyDisplay.Attack.enabled = true;
                EnemyDisplay.AttackValue.enabled = true;
                EnemyDisplay.AttackValue.text = enemy.Damage2.ToString();
            }
            else if (enemy.ActionStep2 == Action.Attack_Debuff)
            {
                EnemyDisplay.Attack_Debuff.enabled = true;
                EnemyDisplay.AttackValue.enabled = true;
                EnemyDisplay.AttackValue.text = enemy.Damage2.ToString();
            }
            else if (enemy.ActionStep2 == Action.Debuff)
            {
                EnemyDisplay.Debuff.enabled = true;
            }
            return;
        }
        else if (turn == "turn3")
        {
            if (enemy.ActionStep3 == Action.Waiting)
            {
                EnemyDisplay.Waiting.enabled = true;
            }
            else if (enemy.ActionStep3 == Action.Attack)
            {
                EnemyDisplay.Attack.enabled = true;
                EnemyDisplay.AttackValue.enabled = true;
                EnemyDisplay.AttackValue.text = enemy.Damage3.ToString();
            }
            else if (enemy.ActionStep3 == Action.Attack_Debuff)
            {
                EnemyDisplay.Attack_Debuff.enabled = true;
                EnemyDisplay.AttackValue.enabled = true;
                EnemyDisplay.AttackValue.text = enemy.Damage3.ToString();
            }
            else if (enemy.ActionStep3 == Action.Debuff)
            {
                EnemyDisplay.Debuff.enabled = true;
            }
            return;
        }
        else if (turn == "turnInterrupt")
        {
            if (enemy.ActionInterrupt == Action.Waiting)
            {
                EnemyDisplay.Waiting.enabled = true;
            }
            else if (enemy.ActionInterrupt == Action.Attack)
            {
                EnemyDisplay.Attack.enabled = true;
                EnemyDisplay.AttackValue.enabled = true;
                EnemyDisplay.AttackValue.text = enemy.DamageInterrupt.ToString();
            }
            else if (enemy.ActionInterrupt == Action.Attack_Debuff)
            {
                EnemyDisplay.Attack_Debuff.enabled = true;
                EnemyDisplay.AttackValue.enabled = true;
                EnemyDisplay.AttackValue.text = enemy.DamageInterrupt.ToString();
            }
            else if (enemy.ActionInterrupt == Action.Debuff)
            {
                EnemyDisplay.Debuff.enabled = true;
            }
            return;
        }
        else { UnityEngine.Debug.Log("hubo un error"); }
    }
}
