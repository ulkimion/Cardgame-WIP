using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowCardDetail : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public Image img;
    [SerializeField] public Image imgArt;

    public Sprite shootMini;
    public Sprite shootBig;
    public Sprite tacticMini;
    public Sprite tacticBig;
    public TextMeshProUGUI efecto;
    public TextMeshProUGUI nombre;
    private Coroutine currentCoroutine;

    void Start()
    {
        img = GetComponent<Image>();
        efecto.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        img.sprite = tacticBig;
        efecto.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        img.sprite = tacticMini;
        efecto.enabled = false;
    }
}
