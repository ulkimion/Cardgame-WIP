using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delinquent_2 : EnemyAITemplate
{
    

    public int enemyAction()
    {
        if (CurrentStep == 1)
        {
            EnemyAttack = 0;
            enemyActionSymbol = Action.Waiting;
            CurrentStep = 2;
        }
        if (CurrentStep == 2)
        {
            EnemyAttack = 8;
            enemyActionSymbol = Action.Attack_Debuff;
            CurrentStep = 1;
            return EnemyAttack;
            //inflingir 2 de fuego
        }
        return 0;
    }
}
