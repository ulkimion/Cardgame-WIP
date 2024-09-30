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
        // Limpiar cartas de la mano antes de robar nuevas
        Transform handTransform = GameObject.FindGameObjectWithTag("Hand").transform;
        /*foreach (Transform child in handTransform)
        {
            Destroy(child.gameObject);  // Eliminar todas las cartas visibles de la mano
        }
        */
        for (int i = 0; i < 5; i++)
        {
            ifDeckEmpty();
            if (battleSystem.deck.Count > 0)
            {
                GameObject card = Instantiate(battleSystem.deck[0].gameObject, cardPositions[i], Quaternion.identity);
                card.transform.SetParent(handTransform);
                card.transform.localScale = Vector3.one * 60;
                card.name = "Card " + (i + 1);
                battleSystem.deck.RemoveAt(0);
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
