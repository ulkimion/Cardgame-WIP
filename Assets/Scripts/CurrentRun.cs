using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new run", menuName = "currentRun")]

public class CurrentRun : ScriptableObject
{
    public int maxHP;
    public int currentHP;
    public int money = 0;
    public List<Card> playerDeck = new List<Card>();
    public List<Bullet> bullets = new List<Bullet>();
    public List<int> exp;
}
