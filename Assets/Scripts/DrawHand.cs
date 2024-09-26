using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawHand : MonoBehaviour
{
    public GameObject Card;
    public BattleSystem battleSystem;

    void Start()
    {
        // Asignar battleSystem si aún no está asignado
        if (battleSystem == null)
        {
            battleSystem = FindObjectOfType<BattleSystem>();
        }
    }


    public void draw5()
    {
        ifDeckEmpty();
        GameObject Card1 = Instantiate(battleSystem.deck[0].gameObject, new Vector3(-4, -3.5f, 0), Quaternion.identity);
        Card1.transform.SetParent(GameObject.FindGameObjectWithTag("Hand").transform);
        Card1.name = "Card 1";
        battleSystem.deck.RemoveAt(0);

        ifDeckEmpty();
        GameObject Card2 = Instantiate(battleSystem.deck[0].gameObject, new Vector3(-2, -3.5f, 0), Quaternion.identity);
        Card2.transform.SetParent(GameObject.FindGameObjectWithTag("Hand").transform);
        Card2.name = "Card 2";
        battleSystem.deck.RemoveAt(0);

        ifDeckEmpty();
        GameObject Card3 = Instantiate(battleSystem.deck[0].gameObject, new Vector3(0, -3.5f, 0), Quaternion.identity);
        Card3.transform.SetParent(GameObject.FindGameObjectWithTag("Hand").transform);
        Card3.name = "Card 3";
        battleSystem.deck.RemoveAt(0);

        ifDeckEmpty();
        GameObject Card4 = Instantiate(battleSystem.deck[0].gameObject, new Vector3(2, -3.5f, 0), Quaternion.identity);
        Card4.transform.SetParent(GameObject.FindGameObjectWithTag("Hand").transform);
        Card4.name = "Card 4";
        battleSystem.deck.RemoveAt(0);

        ifDeckEmpty();
        GameObject Card5 = Instantiate(battleSystem.deck[0].gameObject, new Vector3(4, -3.5f, 0), Quaternion.identity);
        Card5.transform.SetParent(GameObject.FindGameObjectWithTag("Hand").transform);
        Card5.name = "Card 5";
        battleSystem.deck.RemoveAt(0);
    }

    void ifDeckEmpty() 
    {
        Debug.Log("ifdeckempty");
        if (battleSystem.deck.Count == 0)
        {
            battleSystem.Shuffle();
        }
    } 
}
