using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    public CurrentRun currentRun;
    public FloorCounter floorCounter;
    public ListOfScenes EventsBase;
    public ListOfScenes EventsCurrentRun;
    public List<Card> startingDeck = new List<Card>();
    public List<Bullet> startingBullets = new List<Bullet>();
    public ExtraExp extraExp;
    public RewardsBulletChosen rewardsBulletChosen;
    public Bullet bullet;
    public void StartnewGame()
    {
        currentRun.maxHP = 100;
        currentRun.currentHP = 100;
        currentRun.money = 50;
        currentRun.playerDeck.Clear();
        currentRun.bullets.Clear();
        currentRun.exp.Clear();
        extraExp.extraExp = 0;
        rewardsBulletChosen.bullet = bullet;

        currentRun.playerDeck = startingDeck;
        currentRun.bullets = startingBullets;
        floorCounter.floorcounter = 0;



        while (currentRun.exp.Count < 6)
        {
            currentRun.exp.Add(0);
        }

        for (int i = 0; i < 6; i++)
        {
            currentRun.exp[i] = 0;
        }
        PopulateWithRules();
    }
    public void PopulateWithRules()
    {
        // Asegurarse de que EventsCurrentRun esté inicializado
        if (EventsCurrentRun == null)
        {
            Debug.LogError("EventsCurrentRun no está inicializado.");
            return;
        }

        EventsCurrentRun.scenes.Clear();
        List<string> shuffledEvents = EventsBase.scenes.OrderBy(x => Random.value).ToList();
        int targetSize = 48;

        for (int i = 0; i < targetSize; i++)
        {
            EventsCurrentRun.scenes.Add(null);
        }

        // Insertar valores fijos en las posiciones específicas
        EventsCurrentRun.scenes[0] = "RegularCombat";  // Bloque 1
        EventsCurrentRun.scenes[1] = "RegularCombat";  // Bloque 1
        EventsCurrentRun.scenes[2] = "RegularCombat";  // Bloque 1

        EventsCurrentRun.scenes[18] = "Shop";           // Bloque 7
        EventsCurrentRun.scenes[19] = "Shop";           // Bloque 7
        EventsCurrentRun.scenes[20] = "Shop";           // Bloque 7

        EventsCurrentRun.scenes[42] = "Shop";           // Bloque 15
        EventsCurrentRun.scenes[43] = "Shop";           // Bloque 15
        EventsCurrentRun.scenes[44] = "Shop";           // Bloque 15

        EventsCurrentRun.scenes[45] = "RegularCombat";  // Bloque 16
        EventsCurrentRun.scenes[46] = "RegularCombat";  // Bloque 16
        EventsCurrentRun.scenes[47] = "RegularCombat";  // Bloque 16

        var emptyPositions = EventsCurrentRun.scenes
            .Select((value, index) => new { value, index })
            .Where(item => item.value == null) 
            .Select(item => item.index)
            .ToList();

        for (int i = 0; i < emptyPositions.Count; i++)
        {
            if (i < shuffledEvents.Count)
            {
                EventsCurrentRun.scenes[emptyPositions[i]] = shuffledEvents[i];
            }
            else
            {
                Debug.LogWarning($"No hay suficientes eventos para llenar la posición {emptyPositions[i]}.");
            }
        }

        Debug.Log("Contenido de EventsCurrentRun.scenes:");
        foreach (var scene in EventsCurrentRun.scenes)
        {
            Debug.Log(scene);
        }
    }
}