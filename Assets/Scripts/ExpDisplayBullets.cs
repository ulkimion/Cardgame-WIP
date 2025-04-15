using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExpDisplayBullets : MonoBehaviour
{

    public CurrentRun currentRun;
    public GameObject bulletBase;
    public TextMeshProUGUI remainingExpText;
    public int remainingExp = 0;
    public ExtraExp extraexp;

    void Start()
    {
        remainingExp = 1 + currentRun.extraEXP;
        currentRun.extraEXP = 0;
        remainingExpText.text = remainingExp.ToString();
        for (int i = 0; i < currentRun.bullets.Count; i++)
        {
            GameObject bullet = Instantiate(bulletBase, new Vector3(100, 420 - (i * 75), 0), Quaternion.identity);
            BulletState bulletState = bullet.GetComponent<BulletState>();
            bulletState.bullet = currentRun.bullets[i];
            BulletDisplay bulletDisplay = bullet.GetComponent<BulletDisplay>();
            bulletDisplay.bullet = currentRun.bullets[i];
            BulletShowLvExp bulletShowLvExp = bullet.GetComponent<BulletShowLvExp>();
            bulletShowLvExp.bulletNumber = i;
            gain1exp gain1exp = bullet.GetComponentInChildren<gain1exp>();
            gain1exp.bulletNumber = i;


            bullet.transform.SetParent(GameObject.FindGameObjectWithTag("BulletDeck").transform);
            bullet.transform.localScale = Vector3.one * 3000;
        }

    }
    public void decreaseExpCounter()
    {
        remainingExp--;
        remainingExpText.text = remainingExp.ToString();
        if (remainingExp <= 0)
        {
            SceneManager.LoadScene("Events");
        }
    }
}
