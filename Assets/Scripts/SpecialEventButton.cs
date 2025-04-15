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
                SceneManager.LoadScene("BattleScenePolice");
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

                SceneManager.LoadScene("Events");
            }
            else if (option == "Skip card and Gain 2 Exp")
                {
                currentRun.extraEXP = currentRun.extraEXP + 2;
                SceneManager.LoadScene("Bullet Rewards 1");
            }

            else if (option == "Skip bullet and Gain 2 Exp")
            {
                currentRun.extraEXP = currentRun.extraEXP + 2;
                SceneManager.LoadScene("BulletExp");
            }
            else if (option == "Leave store")
            {
                currentRun.extraEXP = currentRun.extraEXP + 2;
                SceneManager.LoadScene("Events");
            }
            else
            {
                SceneManager.LoadScene("Events");
            }
        }
    }

    public void refresh()
    {
            optionText.text = option;
    }
}
