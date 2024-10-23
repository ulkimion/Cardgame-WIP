using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOSS }
public class BattleSystem : MonoBehaviour

{
    private static readonly System.Random rng = new System.Random();
    public List<Card> playerDeck = new List<Card>();
    public List<GameObject> inFightDeck = new List<GameObject>();
    public List<GameObject> hand = new List<GameObject>();
    public List<GameObject> discardPile = new List<GameObject>();
    public GameObject cardBase;

    public List<Enemy> EncounterList = new List<Enemy>();    
    public List<GameObject> Enemies = new List<GameObject>();
    public GameObject enemyBase;

    public Text deckSizeText;
    public Text discardPileSizeText;

    public GameObject playerPrefab;
    public Unit playerUnit;

    public Text dialogueText;
    public BattleHUD playerHUD;
    public DrawHand drawHand;
    public int cardsDrawnPerTurn = 5;
    public Text TurnCounter;
    public Text playerBlock;

    public BattleState state;
    public int currentTurn = 0;

    //Las cosas marcadas con RM (removible) son necesarias en este momento, para el correcto funcionamiento de el juego, pero, mas adelante seran obsoletas

    public void Shuffle()
    {
        if(discardPile.Count >= 1)
        {
            foreach(var card in discardPile)
            {
                inFightDeck.Add(card);
            }
            discardPile.Clear();
        }

        int n = inFightDeck.Count;

        for (int i = n - 1; i > 0; i--)
        {
            int j = rng.Next(0, i + 1); 
            var temp = inFightDeck[i];
            inFightDeck[i] = inFightDeck[j];
            inFightDeck[j] = temp;
        }
    }


    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        deckSizeText.text = playerDeck.Count.ToString();
        discardPileSizeText.text = discardPile.Count.ToString();
        TurnCounter.text = ("Turn 0");


        for (int i = 0; i < EncounterList.Count; i++)
        {
            GameObject enemy = Instantiate(enemyBase, new Vector3((3 * i), -1, 0), Quaternion.identity);
            EnemyDisplay enemyDisplay = enemy.GetComponent<EnemyDisplay>();
            enemyDisplay.enemy = EncounterList[i];
            EnemyTurnPattern enemyTurnPatern = enemy.GetComponent<EnemyTurnPattern>();
            enemyTurnPatern.enemy = EncounterList[i];
            enemyTurnPatern.enemyId = i + 1;
            CombatEnemyState combatEnemyState = enemy.GetComponent<CombatEnemyState>();
            combatEnemyState.enemy = EncounterList[i];
            enemyTurnPatern.combatEnemyState = combatEnemyState;
            enemy.transform.SetParent(GameObject.FindGameObjectWithTag("EnemySpawner1").transform);
            enemy.transform.localScale = Vector3.one * 60;
            Enemies.Add(enemy);
        }
    }

        IEnumerator SetupBattle()
    {
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player"); //RM
        playerUnit = playerGO.GetComponent<Unit>(); //RM


        dialogueText.text = "The fight Begins";

        playerHUD.SetHUD(playerUnit); //RM

        currentTurn = 0;

        yield return new WaitForSeconds(2f);

        for (int i = 0; i < playerDeck.Count; i++)
        {
            GameObject card = Instantiate(cardBase,new Vector3(-3, -8, 0), Quaternion.identity);
            CardDisplay cardDisplay = card.GetComponent<CardDisplay>();
            cardDisplay.card = playerDeck[i];
            CardEffects cardEffects = card.GetComponent<CardEffects>();
            cardEffects.card = playerDeck[i];

            card.transform.SetParent(GameObject.FindGameObjectWithTag("Deck").transform);
            card.transform.localScale = Vector3.one * 60;
            inFightDeck.Add(card);
        }
        

        Shuffle();

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        playerUnit.LoseEnergy(1); //RM
        playerHUD.SetEnergy(playerUnit.unitEnergy);
        dialogueText.text = "Hit!"; //RM
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Your Turn"; //RM



        yield return new WaitForSeconds(2f);

    }

    IEnumerator EnemiesTurn()
    {
        int playerEffectDamage = playerUnit.AffectedbyStatus();
        bool playerDied = playerUnit.TakeDamage(playerEffectDamage);
        playerHUD.SetHP(playerUnit.currentHP);
        if (playerDied)
        {
            state = BattleState.LOSS;
            EndBattle();
        }
        yield return new WaitForSeconds(1f);

        int deadEnemies = 0;

        for (int i = 0; i < Enemies.Count; i++)
        {
            var enemyTurnPattern = Enemies[i].GetComponent<EnemyTurnPattern>();
            var alive = Enemies[i].GetComponent<CombatEnemyState>();
            //actualizar visual vida enemigo
            int enemyEffectDamage = alive.AffectedbyStatus();
            bool currentlyAlive = alive.TakeDamage(enemyEffectDamage);

            if (alive.enemy.currentlyAlive)
                {
                    enemyTurnPattern.enemyTurn();
                    yield return new WaitForSeconds(1f);
                }
            else
            {
                deadEnemies++;
            }
        }

        if (deadEnemies == Enemies.Count)
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                var money = Enemies[i].GetComponent<CombatEnemyState>();
                playerUnit.money = playerUnit.money + money.moneyDrop;
            }
            state = BattleState.WON;
            EndBattle();
            yield break;
        }


            /*
                    if (enemyAI1.currentlyAlive == false && enemyAI2.currentlyAlive == false && enemyAI3.currentlyAlive == false)
                    {
                        EndBattle();
                        yield break;
                    }

                    */
            state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    public IEnumerator EnemyTurn(string unitName, int EnemyAttack)
    {
        dialogueText.text = unitName + " does " + EnemyAttack + " damage"; 
        yield return new WaitForSeconds(1f);
        bool playerDied = playerUnit.TakeDamage(EnemyAttack);
        playerHUD.SetHP(playerUnit.currentHP);
        playerBlock.text = playerUnit.block.ToString();
        yield return new WaitForSeconds(1f);

        if(playerDied)
        {
            state = BattleState.LOSS;
            EndBattle();
        }
        else
        {
            yield break;
        }
    }

    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            dialogueText.text = "YOU WON!";
        }
        else if (state == BattleState.LOSS)
        {
            dialogueText.text = "YOU WERE DEFEATED...";
        }

    }


    void PlayerTurn()
    {
        currentTurn++;
        drawHand.drawHand(cardsDrawnPerTurn);
        playerUnit.unitEnergy = 3;
        playerHUD.SetEnergy(playerUnit.unitEnergy);
        dialogueText.text = "Your Turn";
        TurnCounter.text = "Turn " + currentTurn;
        deckSizeText.text = inFightDeck.Count.ToString();
        discardPileSizeText.text = discardPile.Count.ToString();
        playerUnit.block = 0;
        playerBlock.text = playerUnit.block.ToString();
        GameObject[] deck = inFightDeck.ToArray();
        StartCoroutine(PileInDeck(deck));
        GameObject[] discardpile = discardPile.ToArray();
        StartCoroutine(PileInDiscardPile(discardpile));
    }


    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        if (playerUnit.unitEnergy <= 0)
        {
            dialogueText.text = "Not enough energy";
            return;
        }
        else
        {
            StartCoroutine(PlayerAttack());

        }

    }


    public void OnEndTurnButton()
    {
       
        if (state == BattleState.PLAYERTURN)
        {
            state = BattleState.ENEMYTURN;
            GameObject[] Cards = hand.ToArray();
            StartCoroutine(SlideAndDiscardCards(Cards));
            StartCoroutine(EnemiesTurn());
        }
    }

    private IEnumerator PileInDiscardPile(GameObject[] Cards)
    {
        foreach (GameObject Card in Cards)
        {
                Card.transform.position = new Vector3(3, -8, 0);
        }
        
        yield return null;
    }

    private IEnumerator PileInDeck(GameObject[] Cards)
    {
        foreach (GameObject Card in Cards)
        {
            Card.transform.position = new Vector3(-3, -8, 0);
        }

        yield return null;
    }

    private IEnumerator SlideAndDiscardCards(GameObject[] Cards)
    {
        float staggerTime = 0.03f;
        float duration = 0.3f;

        foreach (GameObject Card in Cards)
        {
            StartCoroutine(SlideCardDown(Card, duration));
            yield return new WaitForSeconds(staggerTime);
        }
        yield return new WaitForSeconds(duration + staggerTime);
    }

    private IEnumerator SlideCardDown(GameObject card, float duration)
    {
        Vector3 startPosition = card.transform.position;
        Vector3 endPosition = startPosition - new Vector3(0, 3.2f, 0);
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            card.transform.position = Vector3.Lerp(startPosition, endPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        card.transform.position = endPosition;

        //var cardComponent = card;
        discardPile.Add(card);
        hand.RemoveAt(0);
        discardPileSizeText.text = discardPile.Count.ToString();
        card.transform.SetParent(GameObject.FindGameObjectWithTag("DiscardPile").transform);
        //GameObject.Destroy(card);
    }

    public bool cleanhit()
    {
        bool cleanHit = playerUnit.CleanHit();
        if (cleanHit) { return true; } else { return false; }
    }

    public void shoot(int shootAmount)
    {
        Debug.Log("shoot" + shootAmount);
        return;
    }

    public void multiShot(int shootAmount)
    {
        Debug.Log("multishoot" + shootAmount);
        return;
    }

}