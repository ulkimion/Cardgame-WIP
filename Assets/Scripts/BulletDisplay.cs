using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class BulletDisplay : MonoBehaviour
{
    public Bullet bullet;
    public TextMeshProUGUI bulletName;
    public TextMeshProUGUI bulletEffect;
    public Image artwork;

    void Start()
    {
        bulletName.text = bullet.name;
        artwork.sprite = bullet.artwork;

        if (bullet.exp is >= 3 and < 8)
        {
            bulletEffect.text = bullet.effectTextLv2;
        }
        else if (bullet.exp > 8)
        {
            bulletEffect.text = bullet.effectTextLv3;
        }
        else
        {
            bulletEffect.text = bullet.effectTextLv1;
        }
    }
}
