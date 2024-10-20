using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class switchimage : MonoBehaviour
{
    [SerializeField] public Image img;
    [SerializeField] public Image imgArt;
    public Sprite imagen1;
    public Sprite imagen2;
    public Sprite imagen3;
    public TextMeshProUGUI textTMP;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        StartCoroutine(Switching());
    }

    public IEnumerator Switching()
    {
        img.sprite = imagen1;
        yield return new WaitForSeconds(5);
        textTMP.text = "Descripción de la carta";
        imgArt.enabled = false;
        img.sprite = imagen2;
        yield return new WaitForSeconds(5);
        //textTMP.text = "";
        textTMP.enabled = false;
        imgArt.enabled = true;
        img.sprite = imagen3;
        yield return new WaitForSeconds(5);
        textTMP.text = "Hola a todos!";
        textTMP.enabled = true;
        img.sprite = imagen1;
    }
}
