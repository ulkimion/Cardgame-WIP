using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDisplay : MonoBehaviour
{
    public Image look;
    public Enemy enemy;
    public Sprite intent;
    public Sprite Waiting;
    public Sprite Attack;
    public Sprite Attack_Debuff;
    public Sprite Debuff;
    public TextMeshProUGUI damage;
    public TextMeshProUGUI Burn;
    public TextMeshProUGUI Paralysis;
    public TextMeshProUGUI Poison;

    void Start()
    {
        look.sprite = enemy.artwork;

    }
}
