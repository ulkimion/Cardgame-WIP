using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BulletRewardsShowBullets : MonoBehaviour
{
    public BulletPool bulletPool;
    public GameObject bulletBase;

    void Start()
    {
        if (bulletPool == null || bulletPool.bullets.Count < 3)
        {
            Debug.LogError("No hay suficientes balas en la BulletPool para seleccionar 3 únicas.");
            return;
        }
        
        List<Bullet> selectedBullets = GetRandomBullets(bulletPool.bullets, 3);
        //GameHandler.instance.IncreaseCounter();
        for (int i = 0; i < selectedBullets.Count; i++)
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
}
