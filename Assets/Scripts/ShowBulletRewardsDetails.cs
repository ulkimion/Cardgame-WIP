using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowBulletRewardsDetails : MonoBehaviour
{
        public Bullet bullet;
        public TextMeshProUGUI bulletName;
        public TextMeshProUGUI bulletDamage;
        public TextMeshProUGUI bulletEffect;
        public Image artwork;
        public TextMeshProUGUI sold;
        public TextMeshProUGUI price;
        private Coroutine currentCoroutine;
        public GetBulletRewards GetBulletRewards;

        void Start()
        {
            GetBulletRewards = GetComponentInParent<GetBulletRewards>();
            artwork = GetComponent<Image>();
            artwork.sprite = bullet.artwork;
            bulletName.enabled = true;
            bulletDamage.enabled = true;
            bulletEffect.enabled = true;
            sold.enabled = false;

            bulletName.text = bullet.name;
            bulletEffect.text = bullet.effectTextLv1;
            bulletDamage.text = bullet.damageLv1.ToString();


            if (GetBulletRewards.price > 0)
                {
                    price.text = GetBulletRewards.price.ToString();
                    price.enabled = true;
                }
                else
                {
                    price.enabled = false;
                }
            }
    }