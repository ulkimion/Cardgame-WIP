using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawHand : MonoBehaviour
{
    public GameObject Card;
    public BattleSystem battleSystem;
    public List<Vector3> cardPositions;

    void Start()
    {
        // Asignar battleSystem si a�n no est� asignado
        if (battleSystem == null)
        {
            battleSystem = FindObjectOfType<BattleSystem>();
        }
    }


    public void drawHand(int quantity)
    {

        cardPositions = new List<Vector3>();
        float offset = (quantity - 1) * 1.75f / 2.0f;
        for (int i = 0; i < quantity; i++)
        {
            float xPos = (i * 1.75f) - offset;
            cardPositions.Add(new Vector3(xPos, -3.5f, 0f));
        }

        for (int i = 0; i < quantity; i++)
        {
            ifDeckEmpty();
            if (battleSystem.inFightDeck.Count > 0)
            {
                battleSystem.hand.Add(battleSystem.inFightDeck[0]);
                battleSystem.inFightDeck.RemoveAt(0);
                battleSystem.hand[i].transform.position = cardPositions[i];
                battleSystem.hand[i].transform.SetParent(GameObject.FindGameObjectWithTag("Hand").transform);
            }
            else
            {
                Debug.Log("Deck vac�o");
            }
        }

    }

    void ifDeckEmpty() 
    {
        if (battleSystem.inFightDeck.Count == 0)
        {
            battleSystem.Shuffle();
        }
    } 
}
