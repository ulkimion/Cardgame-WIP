using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum cardType { Tactic, Shoot }
public enum shootType { None, Shoot, MultiShoot }
public enum cardTarget { Enemy, Self, All }
public enum condition { None, NoBlock, Debuff, WhenTakingAHit  }
[CreateAssetMenu(fileName = "new Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public new string name;
    public string effectText;
    public Sprite artwork;
    public cardType CardType;

    public shootType shootType;
    public cardTarget cardTarget;
    public condition condition;
    public int energyCost = 1;
    public int shoot;
    public int block;
    public float effectModifier = 1;
    public float bulletDamageModifier = 1;
    public int draw;
    public int effectDuration;
    public int burn;
    public int paralysis;
    public int poison;
    public int topdeck;
    public int cycle;
    public int DamageTakenModifier;
    public int blockMultiplier;
    public int damagePlus;
    public int damageMultiplier;
    public int dodge;
    public bool vanishes = false;
    public bool keepBlock = false;
    public bool takeCover = false;  
    public bool destroyBullet = false;
    public bool transformNextBullet = false;
    public bool Overdrive = false;
    public bool burningSpirit = false;
    public bool stormingPressure = false;
    public bool toxicEmotions = false;
    public bool retain;
    
    
    public bool IsRetainable()
    {
        return retain;
    }

    



}
