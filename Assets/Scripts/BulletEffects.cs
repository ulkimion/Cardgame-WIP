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

    public void activateEffects(int shootAmount, float bulletdamageModifier, float effectModifier)
    {
        enemy = BattleSystem.Enemies[BattleSystem.CurrentTarget - 1].GetComponent<CombatEnemyState>();
        for (int i = 0; i < shootAmount; i++)
        {
            if(enemy.Burn > 0)
            {
                int damageWhenHitByBurn = (int)((bullet.damage * bulletdamageModifier) * 1.5);
                Debug.Log("modifier = " + bulletdamageModifier);
                enemy.TakeDamage(damageWhenHitByBurn);
            }
            else
            {
                int damage = (int)((bullet.damage * bulletdamageModifier));

                Debug.Log("modifier = " + bulletdamageModifier);
                enemy.TakeDamage(damage);
            }


            enemy.Burn = enemy.Burn + bullet.burn;
            enemy.Paralysis = enemy.Paralysis + bullet.paralysis;
            enemy.Poison = enemy.Poison + bullet.poison;

            if (bullet.cycle > 0)
            {
                BattleSystem.cycle(bullet.cycle);
            }

            if (bullet.draw > 0)
            {
                BattleSystem.draw(bullet.draw);
            }

            if (enemy.currentHP < 0)
            {
                enemy.currentHP = 0;
                enemy.currentlyAlive = false;
                BattleSystem.TargetAliveEnemy();
            }
        }
        Debug.Log("se hizo " + bullet.damage + " de dano");
    }
}
