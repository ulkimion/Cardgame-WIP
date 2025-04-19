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
    public Text PlayerMoney;
    public CurrentRun currentRun;

    private CardDisplay card1Display;
    private GetRewards card1Rewards;

    private CardDisplay card2Display;
    private GetRewards card2Rewards;

    private CardDisplay card3Display;
    private GetRewards card3Rewards;


    public BulletPool bulletPool;
    public GameObject bulletBase;

    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;


    void Start()
    {
        PlayerMoney.text = "Money = " + currentRun.money.ToString();
        card1Display = card1.GetComponent<CardDisplay>();
        card1Rewards = card1.GetComponent<GetRewards>();

        card2Display = card2.GetComponent<CardDisplay>();
        card2Rewards = card2.GetComponent<GetRewards>();

        card3Display = card3.GetComponent<CardDisplay>();
        card3Rewards = card3.GetComponent<GetRewards>();

        if (cardpool == null || cardpool.GetPoolOfCards().Count < 3)
        {
            Debug.LogError("No hay suficientes cartas en CardPool para seleccionar 6 únicas.");
            return;
        }

        if (bulletPool == null || bulletPool.bullets.Count < 3)
        {
            Debug.LogError("No hay suficientes balas en la BulletPool para seleccionar 3 únicas.");
            return;
        }

        List<Bullet> selectedBullets = GetRandomBullets(bulletPool.bullets, 3);

        List<Card> selectedCards = GetRandomCards(cardpool.GetPoolOfCards(), 3);

        AssignCardValues(card1Display, card1Rewards, selectedCards[0]);
        AssignCardValues(card2Display, card2Rewards, selectedCards[1]);
        AssignCardValues(card3Display, card3Rewards, selectedCards[2]);

        ShowBulletRewardsDetails showBulletRewardsDetails1 = bullet1.GetComponentInChildren<ShowBulletRewardsDetails>();
        showBulletRewardsDetails1.bullet = selectedBullets[0];
        GetBulletRewards getBulletRewards1 = bullet1.GetComponent<GetBulletRewards>();
        getBulletRewards1.bullet = selectedBullets[0];
        if (getBulletRewards1 != null)
        {
            getBulletRewards1.bullet = selectedBullets[0];
        }

        ShowBulletRewardsDetails showBulletRewardsDetails2 = bullet2.GetComponentInChildren<ShowBulletRewardsDetails>();
        showBulletRewardsDetails2.bullet = selectedBullets[1];
        GetBulletRewards getBulletRewards2 = bullet1.GetComponent<GetBulletRewards>();
        getBulletRewards2.bullet = selectedBullets[1];
        if (getBulletRewards2 != null)
        {
            getBulletRewards2.bullet = selectedBullets[1];
        }

        ShowBulletRewardsDetails showBulletRewardsDetails3 = bullet3.GetComponentInChildren<ShowBulletRewardsDetails>();
        showBulletRewardsDetails3.bullet = selectedBullets[2];
        GetBulletRewards getBulletRewards3 = bullet3.GetComponent<GetBulletRewards>();
        getBulletRewards3.bullet = selectedBullets[2];
        if (getBulletRewards3 != null)
        {
            getBulletRewards3.bullet = selectedBullets[2];
        }


        AssignBulletValues(showBulletRewardsDetails1, getBulletRewards1, selectedBullets[0]);
        AssignBulletValues(showBulletRewardsDetails2, getBulletRewards2, selectedBullets[1]);
        AssignBulletValues(showBulletRewardsDetails3, getBulletRewards3, selectedBullets[2]);
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

    private List<Bullet> GetRandomBullets(List<Bullet> bullets, int count)
    {
        List<Bullet> randomBullets = new List<Bullet>();
        List<Bullet> tempPool = new List<Bullet>(bullets);

        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, tempPool.Count);
            randomBullets.Add(tempPool[randomIndex]);
            tempPool.RemoveAt(randomIndex);
        }

        return randomBullets;
    }


    private void AssignBulletValues(ShowBulletRewardsDetails display, GetBulletRewards rewards, Bullet bulletData)
    {
        if (display != null)
        {
            display.bullet = bulletData;
            display.refresh();
        }

        if (rewards != null)
        {
            rewards.bullet = bulletData;
        }
    }
}
