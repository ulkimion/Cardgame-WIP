using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletEffects : MonoBehaviour
{
    BulletState bullet;
    public BattleSystem BattleSystem;
    CombatEnemyState enemy;

    public void Start()
    {
        BattleSystem = GameObject.FindWithTag("CombatSystem").GetComponent<BattleSystem>();
        bullet = GetComponent<BulletState>();
}

    public void activateEffects(int shootAmount)
    {
        enemy = BattleSystem.Enemies[BattleSystem.CurrentTarget - 1].GetComponent<CombatEnemyState>();
        for (int i = 0; i < shootAmount; i++)
        {
            enemy.Burn = enemy.Burn + bullet.burn;
            enemy.Paralysis = enemy.Paralysis + bullet.paralysis;
            enemy.Poison = enemy.Poison + bullet.poison;
            enemy.currentHP = enemy.currentHP - bullet.damage;

            if(bullet.cycle > 0)
            {
                BattleSystem.cycle(bullet.cycle);
            }

            if (enemy.currentHP < 0)
            {
                enemy.currentHP = 0;
                enemy.currentlyAlive = false;
            }
        }
        Debug.Log("se hizo " + bullet.damage + " de dano");
    }
}
