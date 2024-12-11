using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChosenBullet", menuName = "ScriptableObjects/ChosenBullet")]
public class RewardsBulletChosen : ScriptableObject
{
    [SerializeField]
    public Bullet bullet;
}
