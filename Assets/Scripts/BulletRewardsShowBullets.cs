using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BulletRewardsShowBullets : MonoBehaviour
{
    public BulletPool bulletPool;
    public GameObject bulletBase;

    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;

    void Start()
    {
        if (bulletPool == null || bulletPool.bullets.Count < 3)
        {
            Debug.LogError("No hay suficientes balas en la BulletPool para seleccionar 3 únicas.");
            return;
        }

        List<Bullet> selectedBullets = GetRandomBullets(bulletPool.bullets, 3);

        /*for (int i = 0; i < selectedBullets.Count; i++)
        {
            GameObject bullet = Instantiate(bulletBase, new Vector3(170 + (i * 300), 300, 0), Quaternion.identity);
            ShowBulletRewardsDetails showBulletRewardsDetails = bullet.GetComponentInChildren<ShowBulletRewardsDetails>();
            showBulletRewardsDetails.bullet = selectedBullets[i];

            GetBulletRewards getBulletRewards = bullet.GetComponent<GetBulletRewards>();
            if (getBulletRewards != null)
            {
                getBulletRewards.bullet = selectedBullets[i];
            }
            bullet.transform.SetParent(GameObject.FindGameObjectWithTag("BulletDeck").transform);
            bullet.transform.localScale = Vector3.one * 3000;
        }*/

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
