using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardEffects : MonoBehaviour, IPointerClickHandler
{
    public BattleSystem BattleSystem;
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
        BattleSystem = GameObject.FindWithTag("CombatSystem").GetComponent<BattleSystem>();
        Debug.Log("El efecto se activo");

        if (card.cardTarget == cardTarget.Self)
        {
            BattleSystem.playerUnit.block = BattleSystem.playerUnit.block + card.block;
            Debug.Log("se gano block");
        }
        else
        {
            BattleSystem.enemyAI1.currentHP = BattleSystem.enemyAI1.currentHP - card.damage;
            Debug.Log("se disparo");
        }
    }
}
