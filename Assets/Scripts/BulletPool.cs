using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "bulletPool", menuName = "bulletPool")]
public class BulletPool : ScriptableObject
{
    [SerializeField]
    List<Bullet> bullets = new List<Bullet>();
}
