using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;
    public BattleSystem battleSystem;
    public int floorCounter;
    public int experience; 

    public void IncreaseCounter()
    {
        floorCounter++;
    }



    public void Start()
    {
        Singleton();
        DontDestroyOnLoad(this.gameObject);
    }



    public void Singleton()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
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
