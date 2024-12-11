using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SpecialEventButton : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI optionText;
    public CurrentRun currentRun;
    public ExtraExp extraExp;
    public string option;
    private bool isClicked = false;
    void Start()
    {
        optionText.text = option;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Se llego hasta aqui");
        if (!isClicked)
        {
            if (option == "Gain 50 Gold, Fight a combat")
            {
                currentRun.money = currentRun.money + 50;
                SceneManager.LoadScene("BattleScene");
            }
            else if (option == "Gain 5 Exp for your Bullets")
            {
                extraExp.extraExp = 4;
                SceneManager.LoadScene("BulletExp");
            }
            else if (option == "Heal for 15 HP")
            {
                if (currentRun.currentHP + 15 > currentRun.maxHP)
                {
                    currentRun.currentHP = currentRun.maxHP;
                }
                else
                {
                    currentRun.currentHP = currentRun.currentHP + 15;
                }

                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    public void refresh()
    {
            optionText.text = option;
    }
}
