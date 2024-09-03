using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delinquent_1 : EnemyAITemplate
{
    public Delinquent_1()
    {
        unitName = "Delinquent_1";
        currentHP = 40;
        maxHP = 40;
    }

    public int enemyAction()
    {
        if (CurrentStep == 1)
        {
            EnemyAttack = 7;
            enemyActionSymbol = Action.Attack;
            return EnemyAttack;
        }
        else
        {
            return 0;
        }
    }
}
