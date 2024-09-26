using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayAttackCard : MonoBehaviour
{
    [SerializeField] private GameObject _combatSystem;
    [SerializeField] private GameObject _player;
    [SerializeField] private Button _button;
    private BattleSystem battleSystem;
    private void Start()
    {
        _combatSystem = GameObject.FindGameObjectWithTag("CombatSystem");
        _player = GameObject.FindGameObjectWithTag("Player");
        BattleSystem battleSystem = _combatSystem.GetComponent<BattleSystem>();
        _button.onClick.AddListener(this.destroyCard);
        _button.onClick.AddListener(battleSystem.OnAttackButton);
    }
    public void destroyCard()
    {
        Unit player = _player.GetComponent<Unit>();
        if(player.unitEnergy > 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Not Enough Energy");
        }
    }


}
