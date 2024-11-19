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
    public int level = 1;
    public bulletCondition condition;
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
    public int drawLv1;
    public int drawLv2;
    public int drawLv3;
    public int extraDamagePerHeldTurnsLv1;
    public int extraDamagePerHeldTurnsLv2;
    public int extraDamagePerHeldTurnsLv3;
    public bool becomesEmpty = false;
    public bool duplicating = false;
    public bool damagex2 = false;
}
