using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawHand : MonoBehaviour
{
    public GameObject Card;
    public BattleSystem battleSystem;

    public void draw5()
    {
        GameObject Card1 = Instantiate(Card, new Vector3(-4, -3.5f, 0), Quaternion.identity);
        Card1.transform.SetParent(GameObject.FindGameObjectWithTag("Hand").transform);
        Card1.name = "Card 1";

        GameObject Card2 = Instantiate(Card, new Vector3(-2, -3.5f, 0), Quaternion.identity);
        Card2.transform.SetParent(GameObject.FindGameObjectWithTag("Hand").transform);
        Card2.name = "Card 2";

        GameObject Card3 = Instantiate(Card, new Vector3(0, -3.5f, 0), Quaternion.identity);
        Card3.transform.SetParent(GameObject.FindGameObjectWithTag("Hand").transform);
        Card3.name = "Card 3";

        GameObject Card4 = Instantiate(Card, new Vector3(2, -3.5f, 0), Quaternion.identity);
        Card4.transform.SetParent(GameObject.FindGameObjectWithTag("Hand").transform);
        Card4.name = "Card 4";
        
        GameObject Card5 = Instantiate(Card, new Vector3(4, -3.5f, 0), Quaternion.identity);
        Card5.transform.SetParent(GameObject.FindGameObjectWithTag("Hand").transform);
        Card5.name = "Card 5";
    }
}
