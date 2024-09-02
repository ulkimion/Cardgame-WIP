using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAITemplate : MonoBehaviour
{
    public enum Action {Attack, Defend, Debuff, Stunned}
    public string unitName = "enemigo";
    public int maxHP = 80;
    public int currentHP = 80;
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

    public int enemyAction()
    {
        if (CurrentStep == 1)
        {
            EnemyAttack = 14;
            CurrentStep++;
            return EnemyAttack;
        }
        else if (CurrentStep == 2)
        {
            EnemyAttack = 1;
            CurrentStep++;
            return EnemyAttack;
        }
        else if (CurrentStep == 3)
        {
            EnemyAttack = 20;
            CurrentStep = 1;
            return EnemyAttack;
        }
        else 
        {
            CurrentStep = 1;
            return 0; 
        }
       }
}

//each enemy will have a beheaviour that changes in each turn, with an amount of differente behaviours between 2 and 5

