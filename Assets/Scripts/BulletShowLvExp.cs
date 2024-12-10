using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletShowLvExp : MonoBehaviour
{
    public TextMeshProUGUI level;
    public TextMeshProUGUI experience;
    public CurrentRun currentRun;
    public int bulletNumber = 0;

    private void Start()
    { 
        experience.text = currentRun.exp[bulletNumber].ToString();
        if (currentRun.exp[bulletNumber] > 10)
        {
            level.text = "3";
        }
        else if (currentRun.exp[bulletNumber] > 3)
        {
            level.text = "2";
        }
        else
        {
            level.text = "1";
        }
    }

    public void refreshValues()
    {
        experience.text = currentRun.exp[bulletNumber].ToString();
        if (currentRun.exp[bulletNumber] > 10)
        {
            level.text = "3";
        }
        else if (currentRun.exp[bulletNumber] > 3)
        {
            level.text = "2";
        }
        else
        {
            level.text = "1";
        }
    }
}
