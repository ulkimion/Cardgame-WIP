using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletShowLvExp : MonoBehaviour
{
    public TextMeshProUGUI level;
    public TextMeshProUGUI experience;
    public Bullet bullet;

    private void Start()
    {
        experience.text = bullet.exp.ToString();
        if (bullet.exp > 10)
        {
            level.text = "3";
        }
        else if (bullet.exp > 3)
        {
            level.text = "2";
        }
        else
        {
            level.text = "1";
        }
    }
}
