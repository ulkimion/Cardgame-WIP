using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAITemplate : MonoBehaviour
{
    public enum Action {Attack, Attack_Debuff, Debuff, Waiting}
    public Action enemyActionSymbol;
    public string unitName = "enemigo";
    public int maxHP;
    public int currentHP;
    public int CurrentStep = 1;
    public int EnemyAttack = 0;
    public int Burn = 0;
    public int Paralysis = 0;
    public int Poison = 0;


    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
            return true;
        else
            return false;

    }
}

public class Delinquent_2 : EnemyAITemplate
{
    public string unitName = "Delinquent_2";
    maxHP = 40;
    currentHP = 40;

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
    }
}

public class Police_1 : EnemyAITemplate
{
    public string unitName = "Police 1";
    maxHP = 60;
    currentHP = 60;

    public int enemyAction()
    {
        if (CurrentStep == 1)
        {
            EnemyAttack = 6;
            enemyActionSymbol = Action.Waiting;
        }
    }
}

public class Police_2 : EnemyAITemplate
{
    public string unitName = "Police 2";
    maxHP = 30;
    currentHP = 30;

    public int enemyAction()
    {
        if (CurrentStep == 1)
        {
            //agregar un if, if player has debuff, enemyAttack = 15, enemyAction = Action.Attack, return EnemyAttack.
            //gain 8 defense
            EnemyAttack = 0;
            enemyActionSymbol = Action.Waiting;
        }
    }
}
//each enemy will have a beheaviour that changes in each turn, with an amount of differente behaviours between 2 and 5

