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
        int baseIndex = ((int)floorCounter.floorcounter - 1) * 3;

        EventOptions eventButton1 = option1.GetComponent<EventOptions>();
        EventOptions eventButton2 = option2.GetComponent<EventOptions>();
        EventOptions eventButton3 = option3.GetComponent<EventOptions>();

        if (baseIndex < listOfScenes.scenes.Count)
        {
            eventButton1.option = listOfScenes.scenes[baseIndex];
            eventButton1.refresh();
        }
        else
        {
            option1.SetActive(false);
        }

        if (baseIndex + 1 < listOfScenes.scenes.Count)
        {
            eventButton2.option = listOfScenes.scenes[baseIndex + 1];
            eventButton2.refresh();
        }
        else
        {
            option2.SetActive(false);
        }

        if (baseIndex + 2 < listOfScenes.scenes.Count)
        {
            eventButton3.option = listOfScenes.scenes[baseIndex + 2];
            eventButton3.refresh();
        }
        else
        {
            option3.SetActive(false);
        }
    }
}
