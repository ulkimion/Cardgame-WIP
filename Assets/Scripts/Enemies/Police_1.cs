using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police_1 : EnemyAITemplate
{
    

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


