using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GetRewards : MonoBehaviour, IPointerClickHandler
{
    public Card card;
    public CurrentRun currentRun;
    public ShowRewardsDetails showRewardsDetails;
    private bool isClicked = false;
    public int price = 10;
    public Text PlayerMoney;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isClicked)
        {
            if (currentRun.money >= price)
            {
                currentRun.playerDeck.Add(card);
                if (price > 0)
                {
                    showRewardsDetails.sold.enabled = true;
                    currentRun.money = currentRun.money - price;
                    PlayerMoney.text = "Money = " + currentRun.money.ToString();
                    isClicked = false;
                }
            }

            if (price == 0)
            {
                SceneManager.LoadScene("Bullet Rewards 1");
            }
            else
            {
                Debug.Log("no hay suficiente dinero");
            }
        }
    }
}
