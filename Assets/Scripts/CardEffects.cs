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

                if(this.card.vanishes == true)
                {
                    BattleSystem.vanishPile.Add(this.gameObject);
                    this.transform.SetParent(GameObject.FindGameObjectWithTag("VanishZone").transform);
                    this.gameObject.transform.position = new Vector3(1, 8, 0);
                }
                else
                {
                    BattleSystem.discardPile.Add(this.gameObject);
                    this.transform.SetParent(GameObject.FindGameObjectWithTag("DiscardPile").transform);
                    this.gameObject.transform.position = new Vector3(0, 8, 0);

                }
                BattleSystem.hand.Remove(this.gameObject);
                BattleSystem.playerHUD.energyText.text = BattleSystem.playerUnit.unitEnergy + "/3";

                //efectos que se ejecutan tras descartarse
                if (card.draw > 0)
                {
                    BattleSystem.draw(card.draw);
                }
                BattleSystem.drawHand.rearange();
            }
            else { BattleSystem.dialogueText.text = "Not Enough Energy"; }
        }
    }

    public void activateEffect()
    {
        BattleSystem = GameObject.FindWithTag("CombatSystem").GetComponent<BattleSystem>();
        Debug.Log("El efecto se activo");

        BattleSystem.playerUnit.block = BattleSystem.playerUnit.block + card.block;
        BattleSystem.playerBlock.text = BattleSystem.playerUnit.block.ToString();
        BattleSystem.keepBlock = card.keepBlock;
        if (card.cardTarget == cardTarget.Enemy)
        {
            if (card.shootType == shootType.Shoot) 
            {
                BattleSystem.shoot(card.shoot);
                Debug.Log("se disparo");
            }
            else if (card.shootType == shootType.MultiShoot)
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
            else if (card.shootType == shootType.MultiShoot)
            {
                BattleSystem.multiShot(card.shoot);
                Debug.Log("se multidisparo");
            }
        }
        if (card.cycle > 0)
        {
            BattleSystem.cycle(card.cycle);
        }
    }   
}
