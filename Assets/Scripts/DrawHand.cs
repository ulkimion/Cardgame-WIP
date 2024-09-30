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
        // Asignar battleSystem si aún no está asignado
        if (battleSystem == null)
        {
            battleSystem = FindObjectOfType<BattleSystem>();
        }
        cardPositions = new List<Vector3>();
        for (int i = 0; i < 5; i++) cardPositions.Add(new Vector3(-4f + (i*2),-3.5f,0f));
    }


    public void draw5()
    {
        for (int i = 0; i < 5; i++)
        {
            ifDeckEmpty();
            if (battleSystem.deck.Count > 0)
            {
                battleSystem.hand.Add(battleSystem.deck[0]);
                battleSystem.deck.RemoveAt(0);
                battleSystem.hand[i].transform.position = cardPositions[i];
                battleSystem.hand[i].transform.SetParent(GameObject.FindGameObjectWithTag("Hand").transform);
                //battleSystem.hand[i].name = "Card " + (i + 1);
            }
            else
            {
                Debug.Log("Deck vacío");
            }
        }

    }

    void ifDeckEmpty() 
    {
        if (battleSystem.deck.Count == 0)
        {
            battleSystem.Shuffle();
        }
    } 
}
