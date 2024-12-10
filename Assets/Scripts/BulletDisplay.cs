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
    public TextMeshProUGUI bulletDamage;
    public TextMeshProUGUI bulletEffect;
    public Image artwork;

    void Start()
    {
        bulletName.text = bullet.name;
        artwork.sprite = bullet.artwork;

        if (bullet.exp is >= 3 and < 10)
        {
            bulletEffect.text = bullet.effectTextLv2;
            bulletDamage.text = bullet.damageLv2.ToString();
        }
        else if (bullet.exp > 10)
        {
            bulletEffect.text = bullet.effectTextLv3;
            bulletDamage.text = bullet.damageLv3.ToString();
        }
        else
        {
            bulletEffect.text = bullet.effectTextLv1;
            bulletDamage.text = bullet.damageLv1.ToString();
        }
    }
}
