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
        HpBar.UpdateHPBar(currentHP,maxHP);
        if (currentHP <= 0)
            return true;
        else
            return false;

    }
}



