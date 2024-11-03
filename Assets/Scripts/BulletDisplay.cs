using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BulletDisplay : MonoBehaviour
{
    public BulletState bulletState;
    public TextMeshProUGUI bulletName;
    public TextMeshProUGUI bulletEffect;
    public Image artwork;

    void Start()
    {
        bulletState = GetComponent<BulletState>();
        bulletName.text = bulletState.name;
        bulletEffect.text = bulletState.effectText;
        artwork.sprite = bulletState.artwork;
    }
}
