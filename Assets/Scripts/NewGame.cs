using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    public CurrentRun currentRun;
    public List<Card> startingDeck = new List<Card>();
    public List<Bullet> startingBullets = new List<Bullet>();

    public void StartnewGame()
    {
        currentRun.maxHP = 100;
        currentRun.currentHP = 100;
        currentRun.money = 50;
        currentRun.playerDeck.Clear();
        currentRun.bullets.Clear();
        currentRun.exp.Clear();

        currentRun.playerDeck = startingDeck;
        currentRun.bullets = startingBullets;

        while (currentRun.exp.Count < 6)
        {
            currentRun.exp.Add(0);
        }

        // Asignar valores
        for (int i = 0; i < 6; i++)
        {
            currentRun.exp[i] = 0;
        }
    }
}
