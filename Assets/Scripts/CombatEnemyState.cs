using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEnemyState : MonoBehaviour
{
    public Enemy enemy;

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
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;
        //HpBar.UpdateHPBar(currentHP,maxHP);
        if (currentHP <= 0)
        {
            currentlyAlive = false;
        }
        

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
