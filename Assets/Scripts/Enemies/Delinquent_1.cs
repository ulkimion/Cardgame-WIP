using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delinquent_1 : EnemyAITemplate
{
    public string unitName = "Delinquent 1";
    maxHP = 40;
    currentHP = 40;

    public int enemyAction()
    {
        if (CurrentStep == 1)
        {
            EnemyAttack = 7;
            enemyAction = Action.Attack;
            return EnemyAttack;
        }
    }
}
