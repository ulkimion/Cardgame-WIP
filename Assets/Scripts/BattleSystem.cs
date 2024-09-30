using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOSS }

public class BattleSystem : MonoBehaviour
{
    public List<GameObject> deck = new List<GameObject>();
    public List<GameObject> hand = new List<GameObject>();
    public List<GameObject> discardPile = new List<GameObject>();



    public Text deckSizeText;
    public Text discardPileSizeText;

    
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    Unit playerUnit;
    Unit enemyUnit;
    //EnemyAITemplate enemyUnit;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
    //public EnemyHUD enemyHUD1;
    public DrawHand drawHand;
    public Text TurnCounter;
    public Delinquent_1 enemyAI1;
    public Delinquent_2 enemyAI2;
    public Police_1 enemyAI3;
    public Text enemyIntent;
    public int enemyDamage;
    public EnemySpawner enemySpawner;


    public BattleState state;

    public int currentTurn = 0;


    //Las cosas marcadas con RM (removible) son necesarias en este momento, para el correcto funcionamiento de el juego, pero, mas adelante seran obsoletas

    public void Shuffle()
    {
        if(discardPile.Count >= 1)
        {
            foreach(var card in discardPile)
            {
                deck.Add(card);
            }
            discardPile.Clear();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        enemySpawner.spawnEnemy();
        enemyAI1 = new Delinquent_1();
        enemyAI2 = new Delinquent_2();
        enemyAI3 = new Police_1();
        deckSizeText.text = deck.Count.ToString();
        discardPileSizeText.text = deck.Count.ToString();
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player"); //RM
        playerUnit = playerGO.GetComponent<Unit>(); //RM

        GameObject enemyGO = GameObject.FindGameObjectWithTag("Enemy1"); //RM
        enemyUnit = enemyGO.GetComponent<Unit>(); //RM

        dialogueText.text = "A " + enemyUnit.unitName + " wants to fight";

        playerHUD.SetHUD(playerUnit); //RM
        enemyHUD.SetHUD(enemyUnit); //RM

        currentTurn = 0;

        yield return new WaitForSeconds(2f);

        for (int i = 0; i < deck.Count; i++) 
        {
            GameObject card = Instantiate(deck[i], new Vector3(0, -8, 0), Quaternion.identity);
            card.transform.SetParent(GameObject.FindGameObjectWithTag("Deck").transform);
            card.transform.localScale = Vector3.one * 60;
        }




        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        bool enemyDied = enemyUnit.TakeDamage(playerUnit.damage);
        playerUnit.LoseEnergy(1); //RM
        playerHUD.SetEnergy(playerUnit.unitEnergy);
        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "Hit!"; //RM
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Your Turn"; //RM


        yield return new WaitForSeconds(2f);

        if(enemyDied)
        {
            state = BattleState.WON;
            EndBattle();
        }
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

        if (enemyAI1.currentlyAlive)
        {
            int enemyEffectDamage = enemyAI1.AffectedbyStatus();
            bool currentlyAlive = enemyAI1.TakeDamage(enemyEffectDamage);
            //playerHUD.SetHP(enemyAI1.currentHP);  Esto hay que modificarlo para cambiar el hp del enemigo al hp actual en su barra de hp
                if (enemyAI1.currentlyAlive)
                {
                    StartCoroutine(EnemyTurn(enemyAI1.unitName, enemyAI1.EnemyAttack));
                }
                else
                {
                    enemyAI1.enemyDies();
                }
            yield return new WaitForSeconds(1f);
        }


        if (enemyAI2.currentlyAlive)
        {
            int enemyEffectDamage = enemyAI2.AffectedbyStatus();
            bool currentlyAlive = enemyAI2.TakeDamage(enemyEffectDamage);
            //playerHUD.SetHP(enemyAI2.currentHP);  Esto hay que modificarlo para cambiar el hp del enemigo al hp actual en su barra de hp
            if (enemyAI2.currentlyAlive)
            {
                StartCoroutine(EnemyTurn(enemyAI2.unitName, enemyAI2.EnemyAttack));
            }
            else
            {
                enemyAI2.enemyDies();
            }
            yield return new WaitForSeconds(1f);
        }


        if (enemyAI3.currentlyAlive)
        {
            int enemyEffectDamage = enemyAI3.AffectedbyStatus();
            bool currentlyAlive = enemyAI3.TakeDamage(enemyEffectDamage);
            //playerHUD.SetHP(enemyAI3.currentHP);  Esto hay que modificarlo para cambiar el hp del enemigo al hp actual en su barra de hp
            if (enemyAI3.currentlyAlive)
            {
                StartCoroutine(EnemyTurn(enemyAI3.unitName, enemyAI3.EnemyAttack));
            }
            else
            {
                enemyAI3.enemyDies();
            }
            yield return new WaitForSeconds(1f);
        }

        if (enemyAI1.currentlyAlive == false && enemyAI2.currentlyAlive == false && enemyAI3.currentlyAlive == false)
        {
            EndBattle();
            yield break;
        }

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator EnemyTurn(string unitName, int EnemyAttack) 
    {
        dialogueText.text = unitName + " attacks!";
        yield return new WaitForSeconds(1f);
        bool playerDied = playerUnit.TakeDamage(enemyDamage);
        playerHUD.SetHP(playerUnit.currentHP);
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
            Destroy(enemyPrefab);
        }
        else if (state == BattleState.LOSS)
        {
            dialogueText.text = "YOU WERE DEFEATED...";
        }

    }


    void PlayerTurn()
    {
        currentTurn++;
        drawHand.draw5();
        playerUnit.unitEnergy = 3;
        playerHUD.SetEnergy(playerUnit.unitEnergy);
        dialogueText.text = "Your Turn";
        TurnCounter.text = "Turn " + currentTurn;
        enemyDamage = enemyAI1.enemyAction();
        enemyIntent.text = "Enemy will do: " + enemyDamage + " Damage ";
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
        GameObject[] Cards = GameObject.FindGameObjectsWithTag("Card");
        StartCoroutine(SlideAndDiscardCards(Cards));
       
        if (state == BattleState.PLAYERTURN)
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemiesTurn());
        }
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
        Vector3 endPosition = startPosition - new Vector3(0, 3, 0);
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
        //GameObject.Destroy(card);
    }

}