using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ShopCode : MonoBehaviour, IPointerClickHandler
{
    private bool isClicked = false;
    public CardPool cardpool;
    public GameObject card1;
    public GameObject card2;
    public GameObject card3;
    public GameObject card4;
    public GameObject card5;
    public GameObject card6;
    public Text PlayerMoney;
    public CurrentRun currentRun;

    private CardDisplay card1Display;
    private GetRewards card1Rewards;

    private CardDisplay card2Display;
    private GetRewards card2Rewards;

    private CardDisplay card3Display;
    private GetRewards card3Rewards;

    private CardDisplay card4Display;
    private GetRewards card4Rewards;

    private CardDisplay card5Display;
    private GetRewards card5Rewards;

    private CardDisplay card6Display;
    private GetRewards card6Rewards;

    void Start()
    {
        PlayerMoney.text = "Money = " + currentRun.money.ToString();
        card1Display = card1.GetComponent<CardDisplay>();
        card1Rewards = card1.GetComponent<GetRewards>();

        card2Display = card2.GetComponent<CardDisplay>();
        card2Rewards = card2.GetComponent<GetRewards>();

        card3Display = card3.GetComponent<CardDisplay>();
        card3Rewards = card3.GetComponent<GetRewards>();

        card4Display = card4.GetComponent<CardDisplay>();
        card4Rewards = card4.GetComponent<GetRewards>();

        card5Display = card5.GetComponent<CardDisplay>();
        card5Rewards = card5.GetComponent<GetRewards>();

        card6Display = card6.GetComponent<CardDisplay>();
        card6Rewards = card6.GetComponent<GetRewards>();

        if (cardpool == null || cardpool.GetPoolOfCards().Count < 6)
        {
            Debug.LogError("No hay suficientes cartas en CardPool para seleccionar 6 únicas.");
            return;
        }

        List<Card> selectedCards = GetRandomCards(cardpool.GetPoolOfCards(), 6);

        AssignCardValues(card1Display, card1Rewards, selectedCards[0]);
        AssignCardValues(card2Display, card2Rewards, selectedCards[1]);
        AssignCardValues(card3Display, card3Rewards, selectedCards[2]);
        AssignCardValues(card1Display, card1Rewards, selectedCards[3]);
        AssignCardValues(card2Display, card2Rewards, selectedCards[4]);
        AssignCardValues(card3Display, card3Rewards, selectedCards[5]);
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isClicked) { 
          isClicked = false;
          SceneManager.LoadScene("Events");
        }
    }
}
