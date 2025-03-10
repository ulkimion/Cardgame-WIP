using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplaceBulletDisplay : MonoBehaviour
{

    public CurrentRun currentRun;
    public GameObject bulletBase;

    void Start()
    {
        for (int i = 0; i < currentRun.bullets.Count; i++)
        {
            GameObject bullet = Instantiate(bulletBase, new Vector3(100, 420 - (i * 75), 0), Quaternion.identity);
            BulletState bulletState = bullet.GetComponent<BulletState>();
            bulletState.bullet = currentRun.bullets[i];
            BulletDisplay bulletDisplay = bullet.GetComponent<BulletDisplay>();
            bulletDisplay.bullet = currentRun.bullets[i];
            BulletShowLvExp bulletShowLvExp = bullet.GetComponent<BulletShowLvExp>();
            bulletShowLvExp.bulletNumber = i;
            ButtonReplaceBullet buttonReplaceBullet = bullet.GetComponentInChildren<ButtonReplaceBullet>();
            buttonReplaceBullet.bulletNumber = i;

            bullet.transform.SetParent(GameObject.FindGameObjectWithTag("BulletDeck").transform);
            bullet.transform.localScale = Vector3.one * 3000;
        }
    }

}