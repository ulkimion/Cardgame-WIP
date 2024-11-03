using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum bulletCondition { None, Paralysis, Burn, Poison, Debuff, Active, Level, WhenPlayed}

[CreateAssetMenu(fileName = "new Bullet", menuName = "Bullet")]

public class Bullet : ScriptableObject
{
    public new string name;
    public Sprite artwork;
    public int exp;
    public string effectText;
    public int level = 1;
    public int damage;
    public bulletCondition condition;
    public int burn;
    public int paralysis;
    public int poison;
    public int cycle;
    public int gainsEnergy;
    public int heal = 0;
    public int extraDamagePerHeldTurns;


    public string effectTextLv1;
    public string effectTextLv2;
    public string effectTextLv3;
    public int damageLv1;
    public int damageLv2;
    public int damageLv3;
    public int burnLv1;
    public int burnLv2;
    public int burnLv3;
    public int paralysisLv1;
    public int paralysisLv2;
    public int paralysisLv3;
    public int poisonLv1;
    public int poisonLv2;
    public int poisonLv3;
    public int cycleLv1;
    public int cycleLv2;
    public int cycleLv3;
    public int gainsEnergyLv1;
    public int gainsEnergyLv2;
    public int gainsEnergyLv3;
    public int healLv1;
    public int healLv2;
    public int healLv3;
    public int extraDamagePerHeldTurnsLv1;
    public int extraDamagePerHeldTurnsLv2;
    public int extraDamagePerHeldTurnsLv3;


    public int heldTurns = 0;
    public bool becomesEmpty = false;
    public bool duplicating = false;
    public bool damagex2 = false;

    void Start()
    {
        if (exp is >= 3 and < 8) 
        {
            level = 2;
            if (effectTextLv2 != null) {
                effectText = effectTextLv2;
            }
            extraDamagePerHeldTurns = extraDamagePerHeldTurnsLv2;
            damage = damageLv2;
            burn = burnLv2;
            paralysis = paralysisLv2;
            poison = poisonLv2;
            cycle = cycleLv2;
            gainsEnergy = gainsEnergyLv2;
            heal = healLv2;
        }
        else if (exp > 8)
        {
            level = 3;
            if (effectTextLv3 != null)
            {
                effectText = effectTextLv3;
            }
            extraDamagePerHeldTurns = extraDamagePerHeldTurnsLv3;
            damage = damageLv3;
            burn = burnLv3;
            paralysis = paralysisLv3;
            poison = poisonLv3;
            cycle = cycleLv3;
            gainsEnergy = gainsEnergyLv3;
            heal = healLv3;
        }
        else
        {
            level = 1;
            if (effectTextLv2 != null)
            {
                effectText = effectTextLv1;
            }

            extraDamagePerHeldTurns = extraDamagePerHeldTurnsLv1;
            damage = damageLv1;
            burn = burnLv1;
            paralysis = paralysisLv1;
            poison = poisonLv1;
            cycle = cycleLv1;
            gainsEnergy = gainsEnergyLv1;
            heal = healLv1;
        }
    }
}
