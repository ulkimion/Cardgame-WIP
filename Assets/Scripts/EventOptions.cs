using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EventOptions : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI optionText;
    public string option;
    private bool isClicked = false;
    void Start()
    {
        refresh();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Se llego hasta aqui");
        if (!isClicked)
        {
            if (option == "RegularCombat")
            {
                SceneManager.LoadScene("BattleScene");
            }
            else if (option == "SpecialEvent")
            {
                SceneManager.LoadScene("Special Events");
            }
            else if (option == "Shop")
            {
                SceneManager.LoadScene("Shop");
            }
            else
            {
                Debug.Log("hubo un error...");
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    public void refresh()
    {
        if (option == "RegularCombat")
        {
            optionText.text = "Combat";
        }
        else if (option == "SpecialEvent")
        {
            optionText.text = "Special Event";
        }
        else if (option == "Shop")
        {
            optionText.text = "Shop";
        }
        else
        {
            optionText.text = "Error";
        }
    }
}
