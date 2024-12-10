using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GetRewards : MonoBehaviour, IPointerClickHandler
{
    public Card card;
    public CurrentRun currentRun;
    public ShowRewardsDetails showRewardsDetails;
    private bool isClicked = false;
    public int price = 10;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isClicked)
        {
            if (currentRun.money > price)
            {
                currentRun.playerDeck.Add(card);
                if (price > 0)
                {
                    showRewardsDetails.sold.enabled = true;
                    currentRun.money = currentRun.money - price;
                }
            }
            else
            {
                Debug.Log("no hay suficiente dinero");
            }
        }
    }
}
