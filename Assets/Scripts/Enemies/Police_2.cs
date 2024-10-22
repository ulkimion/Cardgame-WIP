using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police_2 : EnemyAITemplate, IEnemy
{
    
    private Police_2()
    {
        unitName = "Police 2";
        maxHP = 30;
        currentHP = 30;
    }
    public int enemyAction()
    {
        if (CurrentStep == 1)
        {
            //agregar un if, if player has debuff, enemyAttack = 15, enemyAction = Action.Attack, return EnemyAttack.
            //gain 8 defense
            EnemyAttack = 0;
        }
        return 0;
    }
}
//each enemy will have a beheaviour that changes in each turn, with an amount of differente behaviours between 2 and 5
