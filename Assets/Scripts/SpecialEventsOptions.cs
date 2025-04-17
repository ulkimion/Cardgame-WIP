using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEventsOptions : MonoBehaviour
{
    public GameObject option1;
    public GameObject option2;
    public GameObject option3;

    private void Start()
    {
        SpecialEventButton specialEventButton1 = option1.GetComponent<SpecialEventButton>();
        specialEventButton1.option = "Gain 50 Gold, Start a combat";
        SpecialEventButton specialEventButton2 = option2.GetComponent<SpecialEventButton>();
        specialEventButton2.option = "Gain 5 Exp for your Bullets";
        SpecialEventButton specialEventButton3 = option3.GetComponent<SpecialEventButton>();
        specialEventButton3.option = "Heal for 15 HP";
        specialEventButton1.refresh();
        specialEventButton2.refresh();
        specialEventButton3.refresh();
    }
}
