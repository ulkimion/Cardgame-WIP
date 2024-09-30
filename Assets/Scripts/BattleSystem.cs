using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState {START, PLAYERTURN, ENEMYTURN, WON, LOSS}

public class BattleSystem : MonoBehaviour
{
    
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
<<<<<<< Updated upstream
=======
    //public EnemyHUD enemyHUD1;
    public DrawHand drawHand;
    public Text TurnCounter;

    public List<EnemyAITemplate> enemyList;

    public Delinquent_1 enemyAI1;
    public Delinquent_2 enemyAI2;
    public Police_1 enemyAI3;
    public Text enemyIntent;
    public int enemyDamage;
    public EnemySpawner enemySpawner;
>>>>>>> Stashed changes


    public BattleState state;

<<<<<<< Updated upstream
    

=======
    public int currentTurn = 0;


    //Las cosas marcadas con RM (removible) son necesarias en este momento, para el correcto funcionamiento de el juego, pero, mas adelante seran obsoletas
    /*
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
    }*/

    public void Shuffle()
    {
        if (discardPile.Count >= 1)
        {
            foreach (var card in discardPile)
            {
                // Reactivar el GameObject de la carta y añadirlo de vuelta al mazo
                card.SetActive(true);
                deck.Add(card);
            }
            discardPile.Clear();
        }
    }
>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
<<<<<<< Updated upstream
=======
        enemySpawner.spawnEnemy();
        enemyAI1 = new Delinquent_1();
        enemyAI2 = new Delinquent_2();
        enemyAI3 = new Police_1();
        enemyList = new List<EnemyAITemplate>();
        enemyList.Add(enemyAI1);
        enemyList.Add(enemyAI2);
        enemyList.Add(enemyAI3);
        Debug.Log(enemyList.Count);
        deckSizeText.text = deck.Count.ToString();
        discardPileSizeText.text = deck.Count.ToString();
>>>>>>> Stashed changes
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();
        
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = "A " + enemyUnit.unitName + " wants to fight";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        playerUnit.LoseEnergy(1);
        playerHUD.SetEnergy(playerUnit.unitEnergy);
        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "Hit!";
        yield return new WaitForSeconds(1f);
        dialogueText.text = "Your Turn";


        yield return new WaitForSeconds(2f);

        if(isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
    }

    IEnumerator EnemyTurn() 
    {
        dialogueText.text = enemyUnit.unitName + " attacks!";
        yield return new WaitForSeconds(1f);
<<<<<<< Updated upstream
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
=======

        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i].currentlyAlive)
            {
                int enemyEffectDamage = enemyList[i].AffectedbyStatus();
                bool currentlyAlive = enemyList[i].TakeDamage(enemyEffectDamage);
                //playerHUD.SetHP(enemyAI1.currentHP);  Esto hay que modificarlo para cambiar el hp del enemigo al hp actual en su barra de hp
                if (enemyList[i].currentlyAlive)
                {
                    StartCoroutine(EnemyTurn(enemyList[i].unitName, enemyList[i].EnemyAttack));
                }
                else
                {
                    enemyList[i].enemyDies();
                }
                yield return new WaitForSeconds(1f);
            }
        }
        /*
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
        */
        int activeEnemy = 0;

        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i].currentlyAlive == true)
            {
                activeEnemy++;
            }
        }
        if (activeEnemy <=0 )
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
>>>>>>> Stashed changes
        playerHUD.SetHP(playerUnit.currentHP);
        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            state = BattleState.LOSS;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
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

    /*
    void PlayerTurn()
    {
        playerUnit.unitEnergy = 3;
        playerHUD.SetEnergy(playerUnit.unitEnergy);
        dialogueText.text = "Your Turn";
    }
<<<<<<< Updated upstream
=======
    */
    void PlayerTurn()
    {
        currentTurn++;
        drawHand.draw5();  // Asegúrate de que este método se llama solo una vez por turno
        playerUnit.unitEnergy = 3;
        playerHUD.SetEnergy(playerUnit.unitEnergy);
        dialogueText.text = "Your Turn";
        TurnCounter.text = "Turn " + currentTurn;
        enemyDamage = enemyAI1.enemyAction();
        enemyIntent.text = "Enemy will do: " + enemyDamage + " Damage ";
    }
>>>>>>> Stashed changes

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        if (playerUnit.unitEnergy == 0)
        {
            dialogueText.text = "Not enough energy";
            return;
        }

        StartCoroutine(PlayerAttack());
    }

    public void OnEndTurnButton()
    {
        if(state == BattleState.PLAYERTURN)
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
<<<<<<< Updated upstream
}
=======

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

        // Agregar la carta a la lista de descartadas (sólo el componente lógico, no el GameObject)
        discardPile.Add(card);

        // Desactivar el GameObject en lugar de destruirlo
        card.SetActive(false);
    }
    /*
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
        GameObject.Destroy(card.gameObject);                                          
    }
    */



}
>>>>>>> Stashed changes
