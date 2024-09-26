using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOSS }

public class BattleSystem : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> discardPile = new List<Card>();
    public List<Card> hand = new List<Card>();
    public bool[] availableCardSlots;

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



    public void drawCard()
    {
        if (deck.Count < 1)
        {
            Shuffle();
        }

        if (deck.Count >= 1)
        {
            Card randCard = deck[Random.Range(0, deck.Count)];
            deck.Remove(randCard);
            deckSizeText.text = deck.ToString();
            discardPileSizeText.text = deck.ToString();           
        }

    }

    public void Shuffle()
    {
        if(discardPile.Count >= 1)
        {
            foreach(Card card in discardPile)
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
        //GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        playerUnit = playerGO.GetComponent<Unit>();

        //GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        GameObject enemyGO = GameObject.FindGameObjectWithTag("Enemy1");
        //enemyUnit = enemyGO.GetComponent<EnemyAITemplate>();
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = "A " + enemyUnit.unitName + " wants to fight";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        currentTurn = 0;

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        bool enemyDied = enemyUnit.TakeDamage(playerUnit.damage);
        playerUnit.LoseEnergy(1);
        playerHUD.SetEnergy(playerUnit.unitEnergy);
        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "Hit!";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Your Turn";


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

        Debug.Log("enemigos van a atacar");

        if (enemyAI1.currentlyAlive)
        {
            int enemyEffectDamage = enemyAI1.AffectedbyStatus();
            bool currentlyAlive = enemyAI1.TakeDamage(enemyEffectDamage);
            //playerHUD.SetHP(enemyAI1.currentHP);
                if (enemyAI1.currentlyAlive)
                {
                    StartCoroutine(EnemyTurn(enemyAI1.unitName, enemyAI1.EnemyAttack));

                    Debug.Log("enemigo 1 ataco");
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
            //playerHUD.SetHP(enemyAI2.currentHP);
            if (enemyAI2.currentlyAlive)
            {
                StartCoroutine(EnemyTurn(enemyAI2.unitName, enemyAI2.EnemyAttack));
                Debug.Log("enemigo 2 ataco");
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
            //playerHUD.SetHP(enemyAI3.currentHP);
            if (enemyAI3.currentlyAlive)
            {
                StartCoroutine(EnemyTurn(enemyAI3.unitName, enemyAI3.EnemyAttack));
                Debug.Log("enemigo 3 ataco");
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
        StartCoroutine(SlideAndDestroyCards(Cards));
       
        if (state == BattleState.PLAYERTURN)
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemiesTurn());
        }
    }

    private IEnumerator SlideAndDestroyCards(GameObject[] Cards)
    {
        float staggerTime = 0.03f; // Tiempo de espera entre que cada carta empieza a moverse
        float duration = 0.3f; // Duración del deslizamiento

        foreach (GameObject Card in Cards)
        {
            // Inicia el deslizamiento de la carta, pero no espera a que termine
            StartCoroutine(SlideCardDown(Card, duration));

            // Espera un tiempo antes de iniciar la siguiente carta
            yield return new WaitForSeconds(staggerTime);
        }

        // Espera a que todas las cartas terminen de deslizarse antes de continuar
        yield return new WaitForSeconds(duration + staggerTime);
    }

    private IEnumerator SlideCardDown(GameObject card, float duration)
    {
        Vector3 startPosition = card.transform.position;
        Vector3 endPosition = startPosition - new Vector3(0, 3, 0); // Ajusta 10 según cuánto quieres que se mueva hacia abajo
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            card.transform.position = Vector3.Lerp(startPosition, endPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null; // Espera un frame antes de continuar
        }

        // Asegúrate de que la carta llegue exactamente a la posición final
        card.transform.position = endPosition;

        // Destruye la carta después del deslizamiento

        Card cardComponent = card.GetComponent<Card>();
        discardPile.Add(cardComponent);
        GameObject.Destroy(card);
    }




}