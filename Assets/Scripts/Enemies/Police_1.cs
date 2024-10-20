using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police_1 : EnemyAITemplate, IEnemy
{
    public Police_1()
    {
        unitName = "Police 1";
        currentHP = 40;
        maxHP = 40;
    }

    public int enemyAction()
    {
        if (CurrentStep == 1)
        {
            EnemyAttack = 6;
            enemyActionSymbol = Action.Waiting;
        }
        return 0;
    }
}


