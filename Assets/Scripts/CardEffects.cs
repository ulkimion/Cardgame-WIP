using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.EventTrigger;

public class CardEffects : MonoBehaviour, IPointerClickHandler
{
    public BattleSystem BattleSystem;
    public Card card;
    private bool isClicked = false;



    public void OnPointerClick(PointerEventData eventData)
    {

        BattleSystem = GameObject.FindWithTag("CombatSystem").GetComponent<BattleSystem>();
        if (!isClicked)
        {
            if (BattleSystem.playerUnit.unitEnergy >= card.energyCost)
            {
                activateEffect();
                BattleSystem.playerUnit.unitEnergy = BattleSystem.playerUnit.unitEnergy - card.energyCost;

                BattleSystem.discardPile.Add(this.gameObject);
                BattleSystem.hand.Remove(this.gameObject);
                this.gameObject.transform.position = new Vector3(0, 8, 0);
                BattleSystem.playerHUD.energyText.text = BattleSystem.playerUnit.unitEnergy + "/3";

            }
            else { BattleSystem.dialogueText.text = "Not Enough Energy"; }
        }
    }

    public void activateEffect()
    {
        BattleSystem = GameObject.FindWithTag("CombatSystem").GetComponent<BattleSystem>();
        Debug.Log("El efecto se activo");

        if (card.cardTarget == cardTarget.Self)
        {
            BattleSystem.playerUnit.block = BattleSystem.playerUnit.block + card.block;
            BattleSystem.playerBlock.text = BattleSystem.playerUnit.block.ToString();
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
