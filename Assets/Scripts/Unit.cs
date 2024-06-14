using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName; 
    public int unitLevel;
    public int damage;
    public int maxHP;
    public int currentHP; 
    public int unitEnergy;

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

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
}