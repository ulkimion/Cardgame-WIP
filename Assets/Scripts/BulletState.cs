using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletState : MonoBehaviour
{
    public Bullet bullet;
    public Sprite artwork;
    public new string name;
    public string effectText;
    public int level;
    public int damage;
    public bulletCondition condition;
    public int burn;
    public int paralysis;
    public int poison;
    public int cycle;
    public int gainsEnergy;
    public int heal;
    public int extraDamagePerHeldTurns;

    public int heldTurns = 0;
    public bool becomesEmpty = false;
    public bool duplicating = false;
    public bool damagex2 = false;

    void Start()
    {
        artwork = bullet.artwork;
        name = bullet.name;
        condition = bullet.condition;
        becomesEmpty = bullet.becomesEmpty;
        duplicating = bullet.duplicating;
        damagex2 = bullet.damagex2;


        if (bullet.exp is >= 3 and < 8)
        {
            level = 2;
            if (bullet.effectTextLv2 != null)
            {
                effectText = bullet.effectTextLv2;
            }
            extraDamagePerHeldTurns = bullet.extraDamagePerHeldTurnsLv2;
            damage = bullet.damageLv2;
            burn = bullet.burnLv2;
            paralysis = bullet.paralysisLv2;
            poison = bullet.poisonLv2;
            cycle = bullet.cycleLv2;
            gainsEnergy = bullet.gainsEnergyLv2;
            heal = bullet.healLv2;
        }
        else if (bullet.exp > 8)
        {
            level = 3;
            if (bullet.effectTextLv3 != null)
            {
                effectText = bullet.effectTextLv3;
            }
            extraDamagePerHeldTurns = bullet.extraDamagePerHeldTurnsLv3;
            damage = bullet.damageLv3;
            burn = bullet.burnLv3;
            paralysis = bullet.paralysisLv3;
            poison = bullet.poisonLv3;
            cycle = bullet.cycleLv3;
            gainsEnergy = bullet.gainsEnergyLv3;
            heal = bullet.healLv3;
        }
        else
        {
            level = 1;
            if (bullet.effectTextLv2 != null)
            {
                effectText = bullet.effectTextLv1;
            }

            extraDamagePerHeldTurns = bullet.extraDamagePerHeldTurnsLv1;
            damage = bullet.damageLv1;
            burn = bullet.burnLv1;
            paralysis = bullet.paralysisLv1;
            poison = bullet.poisonLv1;
            cycle = bullet.cycleLv1;
            gainsEnergy = bullet.gainsEnergyLv1;
            heal = bullet.healLv1;
        }
    }
}
