using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardEffects : MonoBehaviour, IPointerClickHandler
{
    public BattleSystem BattleSystem;
    public Card card;
    private bool isClicked = false;



    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isClicked/* && card.energyCost >= BattleSystem.playerUnit.unitEnergy */)
        {
            activateEffect();
            BattleSystem.playerUnit.unitEnergy = BattleSystem.playerUnit.unitEnergy - card.energyCost;
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
        else if (card.cardTarget == cardTarget.Enemy)
        {
            if (card.shootType == shootType.Shoot) 
            {
                BattleSystem.shoot(card.shoot);
                Debug.Log("se disparo");
            }
            else if (card.shootType == shootType.Shoot)
            {
                BattleSystem.multiShot(card.shoot);
                Debug.Log("se multidisparo");
            }
        }
        else if (card.cardTarget == cardTarget.All)
        {
            if (card.shootType == shootType.Shoot)
            {
                BattleSystem.shoot(card.shoot);
                Debug.Log("se disparo");
            }
            else if (card.shootType == shootType.Shoot)
            {
                BattleSystem.multiShot(card.shoot);
                Debug.Log("se multidisparo");
            }
        }
    }   
}
