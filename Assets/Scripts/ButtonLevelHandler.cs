using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLevelHandler : MonoBehaviour
{
    public string levelName;
    public GameHandler gameHandler;
    public NewGame newgame;

    private void Start()
    {
        gameHandler = GameObject.FindObjectOfType<GameHandler>();
    }

    public void OnClickLoadLevel()
    {
        SceneManager.LoadScene(levelName);
        newgame.StartnewGame();
        gameHandler.StartBattle();
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }
}
