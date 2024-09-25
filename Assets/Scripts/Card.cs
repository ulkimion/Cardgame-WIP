using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int handIndex;
    private BattleSystem battleSystem;

    private void Start()
    {
        battleSystem = FindObjectOfType<BattleSystem>();
    }

    void MoveToDiscardPile()
    {
        battleSystem.discardPile.Add(this);
    }
}
