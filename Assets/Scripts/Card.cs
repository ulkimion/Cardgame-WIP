using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum cardType { Tactic, Shoot }
[CreateAssetMenu(fileName = "new Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public new string name;
    public string effectText;
    public Sprite artwork;
    public cardType CardType;
    public int energyCost;

}
