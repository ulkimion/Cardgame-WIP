    using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDisplay : MonoBehaviour
{
    public Image look;
    public Enemy enemy;
    public Image Waiting;
    public Image Attack;
    public TextMeshProUGUI AttackValue;
    public Image Attack_Debuff;
    public Image Debuff;
    public TextMeshProUGUI damage;
    public TextMeshProUGUI Burn;
    public TextMeshProUGUI Paralysis;
    public TextMeshProUGUI Poison;
    public Image DeadIcon;
    public Image TargetIcon;
    public Image BurnIcon;
    public Image PoisonIcon;
    public Image ParalysisIcon;
    public Slider HPSlider;
    public TextMeshProUGUI HPValue;

    void Start()
    {
        look.sprite = enemy.artwork;
        Waiting.enabled = false;
        Attack.enabled = false;
        AttackValue.enabled = false;
        Attack_Debuff.enabled = false;
        Debuff.enabled = false;
        DeadIcon.enabled = false;
        TargetIcon.enabled = false;
        BurnIcon.enabled = false;
        PoisonIcon.enabled = false;
        ParalysisIcon.enabled = false;
        Burn.enabled = false;
        Poison.enabled = false;
        Paralysis.enabled = false;
}
}
