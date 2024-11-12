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

            int totalBurn = (int)(bullet.burn * effectModifier);
            int totalParalysis = (int)(bullet.paralysis * effectModifier);
            int totalPoison = (int)(bullet.poison * effectModifier);
            enemy.Burn = enemy.Burn + totalBurn;
            enemy.Paralysis = enemy.Paralysis + totalParalysis;
            enemy.Poison = enemy.Poison + totalPoison;

            if (bullet.cycle > 0)
            {
                int totalCycle = (int)(bullet.cycle * effectModifier);
                BattleSystem.cycle(totalCycle);
            }

            if (bullet.draw > 0)
            {
                int totalDraw = (int)(bullet.draw * effectModifier);
                BattleSystem.draw(totalDraw);
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
