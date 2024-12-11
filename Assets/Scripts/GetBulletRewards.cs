using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GetBulletRewards : MonoBehaviour, IPointerClickHandler
{
    public Bullet bullet;
    public CurrentRun currentRun;
    public RewardsBulletChosen rewardsBulletChosen;
    public ShowBulletRewardsDetails ShowBulletRewardsDetails;
    private bool isClicked = false;
    public int price = 10;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Se llego hasta aqui");
        ShowBulletRewardsDetails = GetComponentInChildren<ShowBulletRewardsDetails>();
        if (!isClicked)
        {
            Debug.Log("Se preciono");
            if (currentRun.money > price)
            {
                rewardsBulletChosen.bullet = bullet;
                if (price > 0)
                {
                    ShowBulletRewardsDetails.sold.enabled = true;
                    currentRun.money = currentRun.money - price;
                }
            }
            if (price == 0)
            {
                SceneManager.LoadScene("BulletExp");
            }
            else
            {
                Debug.Log("no hay suficiente dinero");
            }
        }
    }
}