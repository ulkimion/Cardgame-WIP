using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLevelHandler : MonoBehaviour
{
    public string levelName;
    public GameHandler gameHandler;

    private void Start()
    {
        gameHandler = GameObject.FindObjectOfType<GameHandler>();
    }

    public void OnClickLoadLevel()
    {
        SceneManager.LoadScene(levelName);
        gameHandler.StartBattle();
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }
}
