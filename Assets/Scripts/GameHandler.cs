using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public GameHandler instance;
    public BattleSystem battleSystem;

    
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
