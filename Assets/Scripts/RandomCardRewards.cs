using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCardRewards : MonoBehaviour
{
    public CardPool cardpool;
    public GameObject card1;
    public GameObject card2;
    public GameObject card3;

    private CardDisplay card1Display;
    private GetRewards card1Rewards;

    private CardDisplay card2Display;
    private GetRewards card2Rewards;

    private CardDisplay card3Display;
    private GetRewards card3Rewards;

    void Start()
    {
        card1Display = card1.GetComponent<CardDisplay>();
        card1Rewards = card1.GetComponent<GetRewards>();

        card2Display = card2.GetComponent<CardDisplay>();
        card2Rewards = card2.GetComponent<GetRewards>();

        card3Display = card3.GetComponent<CardDisplay>();
        card3Rewards = card3.GetComponent<GetRewards>();

        if (cardpool == null || cardpool.GetPoolOfCards().Count < 3)
        {
            Debug.LogError("No hay suficientes cartas en CardPool para seleccionar 3 únicas.");
            return;
        }

        List<Card> selectedCards = GetRandomCards(cardpool.GetPoolOfCards(), 3);

        AssignCardValues(card1Display, card1Rewards, selectedCards[0]);
        AssignCardValues(card2Display, card2Rewards, selectedCards[1]);
        AssignCardValues(card3Display, card3Rewards, selectedCards[2]);
    }
    private List<Card> GetRandomCards(List<Card> cards, int count)
    {
        List<Card> randomCards = new List<Card>();
        List<Card> tempPool = new List<Card>(cards);

        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, tempPool.Count);
            randomCards.Add(tempPool[randomIndex]);
            tempPool.RemoveAt(randomIndex);
        }

        return randomCards;
    }
    private void AssignCardValues(CardDisplay display, GetRewards rewards, Card cardData)
    {
        if (display != null)
        {
            display.card = cardData;
            display.refresh();
        }

        if (rewards != null)
        {
            rewards.card = cardData;
        }
    }
}
