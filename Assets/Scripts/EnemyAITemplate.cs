using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAITemplate 
{
    public enum Action {Attack, Attack_Debuff, Debuff, Waiting}
    public bool currentlyAlive = true;
    public Action enemyActionSymbol;
    public string unitName = "enemigo";
    public int maxHP;
    public int currentHP;
    public int CurrentStep = 1;
    public int EnemyAttack = 0;
    public int Burn = 0;
    public int Paralysis = 0;
    public int Poison = 0;

    public HpBar HpBar;


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



