using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOSS }

public class BattleSystem : MonoBehaviour
{
    
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
    public Delinquent_1 enemyAI;
    public Text enemyIntent;
    public int enemyDamage;
    public EnemySpawner enemySpawner;


    public BattleState state;

    public int currentTurn = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        enemySpawner.spawnEnemy();
        enemyAI = new Delinquent_1();
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

    IEnumerator EnemyTurn() 
    {
        dialogueText.text = enemyUnit.unitName + " attacks!";
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


    void PlayerTurn()
    {
        currentTurn++;
        drawHand.draw5();
        playerUnit.unitEnergy = 3;
        playerHUD.SetEnergy(playerUnit.unitEnergy);
        dialogueText.text = "Your Turn";
        TurnCounter.text = "Turn " + currentTurn;
        enemyDamage = enemyAI.enemyAction();
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
        if(state == BattleState.PLAYERTURN)
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
}
