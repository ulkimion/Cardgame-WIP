using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class gain1exp : MonoBehaviour
{
    public BulletShowLvExp BulletShowLvExp;
    public CurrentRun currentRun;
    public int bulletNumber = 0;
    public ExpDisplayBullets expDisplayBullets;

    public void plusexperience()
    {
        expDisplayBullets = FindObjectOfType<ExpDisplayBullets>();
        if (expDisplayBullets.remainingExp > 0)
        {
            BulletShowLvExp = GetComponentInParent<BulletShowLvExp>();
            currentRun.exp[bulletNumber] = currentRun.exp[bulletNumber] + 1;
            BulletShowLvExp.refreshValues();
            expDisplayBullets.decreaseExpCounter();
        }
    }
}
