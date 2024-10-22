using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum cardType { Tactic, Shoot }
public enum shootType { None, Shoot, MultiShoot }
public enum cardTarget { Self, Enemy, All }
[CreateAssetMenu(fileName = "new Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public new string name;
    public string effectText;
    public Sprite artwork;
    public cardType CardType;
    public int energyCost;
    public int block;
    public int draw;
    public int damage;
    public int burn;
    public int paralysis;
    public int poison;
    public int shoot;
    public shootType shootType;

}
