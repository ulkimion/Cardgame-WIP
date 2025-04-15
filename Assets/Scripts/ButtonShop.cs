using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class ButtonShop : MonoBehaviour, IPointerClickHandler
{
    public string levelName;
    private bool isClicked = false;
    public GameHandler gameHandler;
    private void Start()
    {
        gameHandler = GameObject.FindObjectOfType<GameHandler>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Se llego hasta aqui");
        if (!isClicked)
        {
            SceneManager.LoadScene("Events");
        }
    }
}
