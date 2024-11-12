using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.EventSystems.EventTrigger;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOSS }
public class BattleSystem : MonoBehaviour

{
    private static readonly System.Random rng = new System.Random();
    public List<Card> playerDeck = new List<Card>();
    public List<GameObject> inFightDeck = new List<GameObject>();
    public List<GameObject> hand = new List<GameObject>();
    public List<GameObject> discardPile = new List<GameObject>();
    public List<GameObject> vanishPile = new List<GameObject>();
    public GameObject cardBase;


    public List<Bullet> bullets = new List<Bullet>();
    public List<GameObject> inFightBullets = new List<GameObject>();
    public GameObject bulletBase;
    public Bullet emptyBullet;

    public List<Enemy> EncounterList = new List<Enemy>();    
    public List<GameObject> Enemies = new List<GameObject>();
    public GameObject enemyBase;

    public Text deckSizeText;
    public Text discardPileSizeText;

    public GameObject playerPrefab;
    public Unit playerUnit;

    public Text dialogueText;
    public BattleHUD playerHUD;
    public Draw drawHand;
    public int cardsDrawnPerTurn = 5;
    public int extraCardsDrawn = 0;
    public bool keepBlock = false;
    public Text TurnCounter;
    public int CurrentTarget = 1;
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
            UnityEngine.UI.Button enemyButton = enemy.GetComponent<UnityEngine.UI.Button>();
            enemyButton.onClick.RemoveAllListeners();
            enemyButton.onClick.AddListener(() => changeTarget(enemyTurnPatern.enemyId));


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

        
        for (int i = 0; i < bullets.Count ; i++)
        {
            //GameObject bullet = Instantiate(bulletBase, new Vector3(-7.7f, 4.5f, 0), Quaternion.identity);
            GameObject bullet = Instantiate(bulletBase, new Vector3(-7.7f, 6, 0), Quaternion.identity);
            BulletState bulletState = bullet.GetComponent<BulletState>();
            bulletState.bullet = bullets[i];
            BulletDisplay bulletDisplay = bullet.GetComponent<BulletDisplay>();
            bulletDisplay.bullet = bullets[i];

            bullet.transform.localScale = Vector3.one * 1;
            bullet.transform.SetParent(GameObject.FindGameObjectWithTag("BulletDeck").transform);
            inFightBullets.Add(bullet);
        }

        if (inFightBullets.Count > 0 && inFightBullets[0] != null)
        {
            inFightBullets[0].transform.position = new Vector3(-7.7f, 4.5f, 0);
        }


        Shuffle();

        state = BattleState.PLAYERTURN;
        PlayerTurn();
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

        for (int i = 0; i < Enemies.Count; i++)
        {
            var enemyTurnPattern = Enemies[i].GetComponent<EnemyTurnPattern>();
            var alive = Enemies[i].GetComponent<CombatEnemyState>();
            //actualizar visual vida enemigo
            int enemyEffectDamage = alive.AffectedbyStatus();
            alive.TakeDamage(enemyEffectDamage);

            if (alive.currentlyAlive)
                {
                    enemyTurnPattern.enemyTurn();
                    yield return new WaitForSeconds(1f);
            }
            alive.LoseStatus(1);
        }



        
        checkIfEnemiesAreAlive();
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
        TargetAliveEnemy();
        drawHand.drawHand(cardsDrawnPerTurn + extraCardsDrawn);
        extraCardsDrawn = 0;
        playerUnit.unitEnergy = 3;
        playerHUD.SetEnergy(playerUnit.unitEnergy);
        dialogueText.text = "Your Turn";
        TurnCounter.text = "Turn " + currentTurn;
        deckSizeText.text = inFightDeck.Count.ToString();
        discardPileSizeText.text = discardPile.Count.ToString();
        GameObject[] deck = inFightDeck.ToArray();
        StartCoroutine(PileInDeck(deck));
        GameObject[] discardpile = discardPile.ToArray();
        StartCoroutine(PileInDiscardPile(discardpile));
        if(keepBlock == true)
        {
            keepBlock = false;
        }
        else
        {
            playerUnit.block = 0;
            playerBlock.text = playerUnit.block.ToString();
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

    public void changeTarget(int enemyId)
    {
        int TargetedEnemy = enemyId -1;
        int lastTargetedEnemy = CurrentTarget - 1;

        CombatEnemyState combatEnemyState = Enemies[TargetedEnemy].GetComponent<CombatEnemyState>();
        EnemyDisplay enemyDisplay = Enemies[TargetedEnemy].GetComponent<EnemyDisplay>();
        EnemyDisplay lastEnemyDisplay = Enemies[lastTargetedEnemy].GetComponent<EnemyDisplay>();
        if (combatEnemyState.currentlyAlive == true)
        {
            CurrentTarget = enemyId;
            lastEnemyDisplay.TargetIcon.enabled = false;
            enemyDisplay.TargetIcon.enabled = true;
        }

    }

    public void TargetAliveEnemy()
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            CombatEnemyState combatEnemyState = Enemies[i].GetComponent<CombatEnemyState>();
            if(combatEnemyState.currentlyAlive == true)
            {
                EnemyDisplay enemyDisplay = Enemies[i].GetComponent<EnemyDisplay>();
                EnemyDisplay lastEnemyDisplay = Enemies[CurrentTarget - 1].GetComponent<EnemyDisplay>();
                lastEnemyDisplay.TargetIcon.enabled = false;
                enemyDisplay.TargetIcon.enabled = true;
                CurrentTarget = i + 1;
                return;
            }
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
            bool retainable = Cards[0].GetComponent<CardEffects>().card.retain;
            /*if (retainable == true)
            {
                hand.Add(Card);
                hand.RemoveAt(0);
            }
            else
            {*/
                StartCoroutine(SlideCardDown(Card, duration));
                yield return new WaitForSeconds(staggerTime);
            //}
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
        discardPile.Add(card);
        hand.RemoveAt(0);
        discardPileSizeText.text = discardPile.Count.ToString();
        card.transform.SetParent(GameObject.FindGameObjectWithTag("DiscardPile").transform);
    }

    public bool cleanhit()
    {
        bool cleanHit = playerUnit.CleanHit();
        if (cleanHit) { return true; } else { return false; }
    }

    public void shoot(int shootAmount, float bulletdamageModifier, float effectModifier)
    {
        var alive = Enemies[CurrentTarget - 1].GetComponent<CombatEnemyState>();
        var bullet = inFightBullets[0].GetComponent<BulletEffects>();
        EnemyDisplay enemyDisplay = Enemies[CurrentTarget - 1].GetComponent<EnemyDisplay>();
        if (alive.currentlyAlive == true)
            {
                bullet.activateEffects(shootAmount, bulletdamageModifier, effectModifier);
                //enemyDisplay.HPSlider.value = alive.currentHP / alive.maxHP;
            if (alive.currentHP == 0)
            {
                enemyDisplay.TargetIcon.enabled = false;
                enemyDisplay.DeadIcon.enabled = true;
                enemyDisplay.BurnIcon.enabled = false;
                enemyDisplay.ParalysisIcon.enabled = false;
                enemyDisplay.PoisonIcon.enabled = false;
                checkIfEnemiesAreAlive();
            }
            else
            {
                if (alive.Burn > 0)
                {
                    enemyDisplay.BurnIcon.enabled = true;
                }

                if (alive.Poison > 0)
                {
                    enemyDisplay.PoisonIcon.enabled = true;
                }
                if (alive.Paralysis > 0)
                {
                    enemyDisplay.ParalysisIcon.enabled = true;
                }
            }
        }
         else 
            {
                Debug.Log("como terminamos aqui?");
            }
        cycle(1);

        Debug.Log("shoot" + shootAmount);
        return;
    }


    public void multiShot(int shootAmount)
    {
        Debug.Log("multishoot" + shootAmount);
        return;
    }

    private void checkIfEnemiesAreAlive()
    {
        int deadEnemies = 0;
        for(int i = 0; i < Enemies.Count; i++)
        {
            CombatEnemyState combatEnemyState = Enemies[i].GetComponent<CombatEnemyState>();
            if (combatEnemyState.currentlyAlive == false)
            {
                deadEnemies++;
            }
            else
            {
                return;
            }
        }

        Debug.Log("hay " + deadEnemies + " muertos de " + Enemies.Count);
        if (deadEnemies == Enemies.Count)
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                var money = Enemies[i].GetComponent<CombatEnemyState>();
                playerUnit.money += money.moneyDrop;
            }

            state = BattleState.WON;
            EndBattle();
        }
    }

    public void cycle(int cycleAmount)
    {
        for (int i = 0; i < cycleAmount; i++) 
        {
            var firstBullet = inFightBullets[0];
            var nextBullet = inFightBullets[1];
            nextBullet.transform.position = new Vector3(-7.7f, 4.5f, 0);
            firstBullet.transform.position = new Vector3(-7.7f, 6, 0);
            inFightBullets.Add(inFightBullets[0]);
            inFightBullets.RemoveAt(0);
            Debug.Log("cycle");
        }
    }

    public void draw(int drawAmmount) {
        drawHand.draw(drawAmmount); 
    }
}