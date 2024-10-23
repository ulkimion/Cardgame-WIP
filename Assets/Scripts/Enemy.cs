using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Action { Waiting, Attack, Attack_Debuff, Debuff }
public enum Interrupt { Never, Paralysis, Burn, Poison }
[CreateAssetMenu(fileName = "new Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public bool currentlyAlive = true;
    public string unitName = "enemigo";
    public int maxHP;
    public int currentHP;
    public int block;
    public int focus;
    public int CurrentStep = 1;
    public int EnemyAttack = 0;
    public int Burn = 0;
    public int Paralysis = 0;
    public int Poison = 0;
    public HpBar HpBar;
    public Sprite artwork;
    public int moneyDrop = 50;

    public int NumberOfSteps = 1;
    public Interrupt Interrupt;

    public Action ActionStep1;
    public bool OnHit1;
    public int Block1;
    public int Damage1;
    public int Tangled1;
    public int InfBurn1;
    public int InfParalysis1;
    public int InfPoison1;
    public int GainBlock1;
    public int GainFocus1;

    public Action ActionStep2;
    public bool OnHit2;
    public int Block2;
    public int Damage2;
    public int InfBurn2;
    public int InfParalysis2;
    public int InfPoison2;
    public int GainBlock2;
    public int GainFocus2;

    public Action ActionStep3;
    public bool OnHit3;
    public int Block3;
    public int Damage3;
    public int InfBurn3;
    public int InfParalysis3;
    public int InfPoison3;
    public int GainBlock3;
    public int GainFocus3;
 
    public Action ActionInterrupt;
    public bool OnHitInterrupt;
    public int BlockInterrupt;
    public int DamageInterrupt;
    public int InfBurnInterrupt;
    public int InfParalysisInterrupt;
    public int InfPoisonInterrupt;
    public int GainBlockInterrupt;
    public int GainFocusInterrupt;

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;
        //HpBar.UpdateHPBar(currentHP,maxHP);
        if (currentHP <= 0)
            return true;
        else
            return false;

    }
    public int AffectedbyStatus()
    {
        int damage = (Burn + Paralysis + Poison);
        LoseStatus(1);
        return damage;
    }

    public void LoseStatus(int statusLoss)
    {
        Burn = Mathf.Max(0, Burn - statusLoss);
        Paralysis = Mathf.Max(0, Paralysis - statusLoss);
        Poison = Mathf.Max(0, Poison - statusLoss);
        return;
    }

    public void enemyDies()
    {
        currentlyAlive = false;
    }
}