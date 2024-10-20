using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class showCardDetail : MonoBehaviour
{
    [SerializeField] public Image img;
    [SerializeField] public Image imgArt;

    public Sprite shootMini;
    public Sprite shootBig;
    public Sprite tacticMini;
    public Sprite tacticBig;
    public TextMeshProUGUI efecto;
    public TextMeshProUGUI nombre;

    void Start()
    {
        img = GetComponent<Image>();
        efecto.enabled = false;
        StartCoroutine(ShowBigVersion());
    }

    public IEnumerator ShowBigVersion()
    {
        yield return new WaitForSeconds(5);
        img.sprite = tacticBig;
        efecto.enabled = true;
        StartCoroutine(ShowMiniVersion());
    }

    public IEnumerator ShowMiniVersion()
    {
        yield return new WaitForSeconds(5);
        img.sprite = tacticMini;
        efecto.enabled = false;
        StartCoroutine(ShowMiniVersion());
    }
}
