using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "cardPool", menuName = "cardPool")]
public class CardPool : ScriptableObject
{
    [SerializeField]
    List<Card> poolOfCards = new List<Card>();
    public List<Card> GetPoolOfCards()
    {
        return poolOfCards;
    }
}
