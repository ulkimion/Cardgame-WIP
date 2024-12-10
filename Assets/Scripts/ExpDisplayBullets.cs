using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpDisplayBullets : MonoBehaviour
{

    public CurrentRun currentRun;
    public GameObject bulletBase;
    void Start()
    {
        for (int i = 0; i < currentRun.bullets.Count; i++)
        {
            GameObject bullet = Instantiate(bulletBase, new Vector3(50, 400 - (i * 75), 0), Quaternion.identity);
            BulletState bulletState = bullet.GetComponent<BulletState>();
            bulletState.bullet = currentRun.bullets[i];
            BulletDisplay bulletDisplay = bullet.GetComponent<BulletDisplay>();
            bulletDisplay.bullet = currentRun.bullets[i];
            BulletShowLvExp bulletShowLvExp = bullet.GetComponent<BulletShowLvExp>();
            bulletShowLvExp.bullet = currentRun.bullets[i];

            bullet.transform.localScale = Vector3.one * 35;
            bullet.transform.SetParent(GameObject.FindGameObjectWithTag("BulletDeck").transform);
        }

    }
}
