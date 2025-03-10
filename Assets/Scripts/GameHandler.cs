using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public GameHandler instance;
    public BattleSystem battleSystem;
    public CurrentRun currentRun;
    public FloorCounter floorCounter;
    public ListOfScenes EventsBase;
    public ListOfScenes EventsCurrentRun;
    public List<Card> startingDeck = new List<Card>();
    public List<Bullet> startingBullets = new List<Bullet>();
    public ExtraExp extraExp;
    public RewardsBulletChosen rewardsBulletChosen;
    public Bullet bullet;

    public void Start()
    {
        Singleton();
        DontDestroyOnLoad(gameObject);
    }


    public void Singleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void StartBattle()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        battleSystem = GameObject.FindObjectOfType<BattleSystem>();

        
    }
}
