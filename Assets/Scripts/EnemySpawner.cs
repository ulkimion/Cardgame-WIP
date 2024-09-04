using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject EnemyB;
    public GameObject EnemyC;

    public void spawnEnemy()
    {
        GameObject Enemy1 = Instantiate(Enemy, new Vector3(4, -1.5f, 0), Quaternion.identity);
        Enemy1.transform.SetParent(GameObject.FindGameObjectWithTag("EnemySpawner1").transform);

        GameObject Enemy2 = Instantiate(EnemyB, new Vector3(6, -1.5f, 0), Quaternion.identity);
        Enemy2.transform.SetParent(GameObject.FindGameObjectWithTag("EnemySpawner1").transform);


        GameObject Enemy3 = Instantiate(EnemyC, new Vector3(8, -1.5f, 0), Quaternion.identity);
        Enemy3.transform.SetParent(GameObject.FindGameObjectWithTag("EnemySpawner1").transform);
    }

}
