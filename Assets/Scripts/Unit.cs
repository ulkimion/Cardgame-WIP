using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int damage;
    public int maxHP;
    public int currentHP; 
    public int block = 0;
    public int unitEnergy;
    public int Burn = 0;
    public int Paralysis = 0;
    public int Poison = 0;
    public int money = 0;


    public bool TakeDamage(int dmg)
    {
        Debug.Log("se hizo " + dmg + " de danio");
        if (dmg <= block) {
            block = block - dmg;
        }
        else
        {
            currentHP = currentHP - (dmg - block);
            block = 0;
        }

        if(currentHP <= 0)
            return true;
        else
            return false;

    }

    public bool LoseEnergy(int loss)
    {
        unitEnergy -= loss;
        return true;
    }

    public int AffectedbyStatus()
    {
        damage = (Burn + Paralysis + Poison);
        LoseStatus(1);
        return damage;
    }

    public void LoseStatus(int statusLoss)
    {
        Burn = Mathf.Max(0, Burn - statusLoss);
        Paralysis = Mathf.Max(0, Paralysis - statusLoss);
        Poison = Mathf.Max(0, Poison - statusLoss);
        return;
    }

    public bool CleanHit()
    {
        if (block > 0)
        {
            return false;
        }
        else
        {
            return true;
        } 
    }
}