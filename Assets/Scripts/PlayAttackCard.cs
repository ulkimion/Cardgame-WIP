using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayAttackCard : MonoBehaviour
{
    /*
    [SerializeField] private GameObject _combatSystem;
    [SerializeField] private GameObject _player;
    [SerializeField] private Button _button;
    private BattleSystem battleSystem;
    private void Start()
    {
        _combatSystem = GameObject.FindGameObjectWithTag("CombatSystem");
        _player = GameObject.FindGameObjectWithTag("Player");
        battleSystem = _combatSystem.GetComponent<BattleSystem>();
        _button.onClick.AddListener(this.discardCard);
        _button.onClick.AddListener(battleSystem.OnAttackButton);
    }
    public void discardCard()
    {
        Unit player = _player.GetComponent<Unit>();
        if(player.unitEnergy > 0)
        {
            battleSystem.discardPile.Add(this.gameObject);
            battleSystem.hand.Remove(this.gameObject);
            this.gameObject.transform.position = new Vector3(0, 8, 0);
        }
        else
        {
            Debug.Log("Not Enough Energy");
        }
    }*/


}
