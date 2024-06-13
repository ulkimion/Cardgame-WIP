using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawHand : MonoBehaviour
{
    public GameObject Carta;

    void Update()
    {
        Instantiate(Carta, Player Hand);
    }
}
