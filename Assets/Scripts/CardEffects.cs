using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardEffects : MonoBehaviour, IPointerClickHandler
{
    public Card card;
    private bool isClicked = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isClicked) //y la energia de la carta =< energia jugador
        {
            activateEffect();
            //cardSelectionHandler.Discard();
        }
    }

    public void activateEffect()
    {
        Debug.Log("El efecto se activo");
    }
}
