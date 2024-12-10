using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ListOfScenes", menuName = "ScriptableObjects/ListOfScenes", order = 1)]
public class ListOfScenes : ScriptableObject
{
    [SerializeField]
    public List<string> scenes = new List<string>();
}