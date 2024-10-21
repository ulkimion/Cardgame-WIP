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
    //[SerializeField] public Card cardType;
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
        //CardDisplay cardDisplay = GetComponent<Card>();
        /*if (cardDisplay.cardType == cardType.Shoot)
        {
            img.sprite = shootMini;
        }
        else
        { */
            img.sprite = tacticMini;
        //}
        efecto.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        /*if (type == cardType.Shoot)
        {
            img.sprite = shootBig;
        }
        else
        { */
            img.sprite = tacticBig;
        //}
        efecto.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        /*if (type == cardType.Shoot)
        {
            img.sprite = shootMini;
        }
        else
        { */
            img.sprite = tacticMini;
        //}
        efecto.enabled = false;
    }
}
