using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonReplaceBullet : MonoBehaviour
{
    public CurrentRun currentRun;
    public int bulletNumber = 0;
    public GameHandler gameHandler;

    public void replaceBullet()
    {
        gameHandler = FindObjectOfType <GameHandler>();
        currentRun.bullets.RemoveAt(bulletNumber);
        currentRun.bullets.Add(gameHandler.bullet);
        SceneManager.LoadScene("Events");
    }

}
