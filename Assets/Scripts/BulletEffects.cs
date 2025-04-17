using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        int bulletDamage = bullet.damage;
        int bulletTotalBurn = bullet.burn;
        int bulletTotalParalysis = bullet.paralysis;
        int bulletTotalPoison = bullet.poison;

        if (BattleSystem.burningSpirit == true)
        {
            bulletTotalBurn = bulletTotalBurn + 3;
        }
        if (BattleSystem.stormingPressure == true)
        {
            bulletDamage = (int)bulletDamage / 2;
            bulletTotalParalysis = bulletTotalParalysis + 3;
        }
        if (BattleSystem.toxicEmotions == true)
        {
            bulletDamage = 0;
            bulletTotalBurn = bulletTotalBurn *2;
            bulletTotalParalysis = bulletTotalParalysis * 2;
            bulletTotalPoison = bulletTotalPoison * 2;
        }


        enemy = BattleSystem.Enemies[BattleSystem.CurrentTarget - 1].GetComponent<CombatEnemyState>();
        for (int i = 0; i < shootAmount; i++)
        {
            if(enemy.Burn > 0 && BattleSystem.burningSpirit != true)
            {
                int damageWhenHitByBurn = (int)((bulletDamage * bulletdamageModifier) * 1.5);
                Debug.Log("modifier = " + bulletdamageModifier);
                enemy.TakeDamage(damageWhenHitByBurn);
            }
            else
            {
                int damage = (int)((bulletDamage * bulletdamageModifier));

                Debug.Log("modifier = " + bulletdamageModifier);
                enemy.TakeDamage(damage);
            }

            int totalBurn = (int)(bulletTotalBurn * effectModifier);
            int totalParalysis = (int)(bulletTotalParalysis * effectModifier);
            int totalPoison = (int)(bulletTotalPoison * effectModifier);
            enemy.Burn = enemy.Burn + totalBurn;
            enemy.Paralysis = enemy.Paralysis + totalParalysis;
            enemy.Poison = enemy.Poison + totalPoison;
            enemy.updateStatus();

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
        Debug.Log("se hizo " + bulletDamage + " de dano");
    }
}
