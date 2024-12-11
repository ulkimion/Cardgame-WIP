using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectEventOptions : MonoBehaviour
{
    public ListOfScenes listOfScenes;
    public FloorCounter floorCounter;
    public GameObject option1;
    public GameObject option2;
    public GameObject option3;

    private void Start()
    {
        floorCounter.floorcounter++;
        EventOptions eventButton1 = option1.GetComponent<EventOptions>();
        eventButton1.option = listOfScenes.scenes[(((int)floorCounter.floorcounter - 1) * 3)];
        EventOptions eventButton2 = option2.GetComponent<EventOptions>();
        eventButton2.option = listOfScenes.scenes[(((int)floorCounter.floorcounter - 1) * 3) + 1];
        EventOptions eventButton3 = option3.GetComponent<EventOptions>();
        eventButton3.option = listOfScenes.scenes[(((int)floorCounter.floorcounter - 1) * 3) + 2];
        eventButton1.refresh();
        eventButton2.refresh();
        eventButton3.refresh();
    }
}
