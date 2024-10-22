using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delinquent_1 : Enemy, IEnemy
{
    public Delinquent_1()
    {
        unitName = "Delinquent 1";
        currentHP = 40;
        maxHP = 40;
    }

    public int enemyAction()
    {
        if (CurrentStep == 1)
        {
            EnemyAttack = 7;
            return EnemyAttack;
        }
        else
        {
            return 0;
        }
    }
}
