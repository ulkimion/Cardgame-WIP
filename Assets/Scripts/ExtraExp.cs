using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AddExtraExp", menuName = "extraExp")]
public class ExtraExp : ScriptableObject
{
    [SerializeField]
    public int extraExp;
}
