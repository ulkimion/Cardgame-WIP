using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEnemyState : MonoBehaviour
{
    public Enemy enemy;

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
