using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;

    [SerializeField] private GameObject _combatSystem;
    public void spawnEnemy()
    {
        GameObject Enemy1 = Instantiate(Enemy, new Vector3(4, -1.5f, 0), Quaternion.identity);
        Enemy1.transform.SetParent(GameObject.FindGameObjectWithTag("EnemySpawner1").transform);
    }

}
