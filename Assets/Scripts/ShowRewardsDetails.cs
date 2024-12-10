using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowRewardsDetails : MonoBehaviour
{
    [SerializeField] public Image img;
    [SerializeField] public Image imgArt;
    public Sprite shootBig;
    public Sprite tacticBig;
    public TextMeshProUGUI efecto;
    public TextMeshProUGUI nombre;
    public TextMeshProUGUI sold;
    public TextMeshProUGUI price;
    private Coroutine currentCoroutine;
    public GetRewards GetRewards;

    void Start()
    {
        img = GetComponent<Image>();
        img.sprite = tacticBig;
        efecto.enabled = true;
        sold.enabled = false;

        if (GetRewards.price > 0)
        {
            price.text = GetRewards.price.ToString();
            price.enabled = true;
        }
        else
        {
            price.enabled = false;
        }
    }
}