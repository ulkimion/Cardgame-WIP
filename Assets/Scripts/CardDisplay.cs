using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public TextMeshProUGUI cardname;
    public TextMeshProUGUI effectText;
    public Image artwork;
    public TextMeshProUGUI energyCost;



    void Start()
    {
        cardname.text = card.name;
        effectText.text = card.effectText;
        energyCost.text = card.energyCost.ToString();
        artwork.sprite = card.artwork;
    }




}
