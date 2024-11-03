using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        //bulletName.text = bullet.name;
        //bulletEffect.text = bullet.effectTextLv1;
        //artwork.sprite = bullet.artwork;
    }
}
