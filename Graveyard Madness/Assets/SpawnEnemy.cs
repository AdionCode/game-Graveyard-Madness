using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnEnemy : MonoBehaviour
{
    public Transform[] spawnPos;
    public GameObject[] enemyPrefabs;

    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    void Update()
    {

    }

    //Spawn Enemy dengan jeda waktu menggunakan courotine
    IEnumerator spawnEnemy()
    {
        while (true)
        {
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);
            int randomSpawn = Random.Range(0, spawnPos.Length);

            Instantiate(enemyPrefabs[randomEnemy], spawnPos[randomSpawn].position, transform.rotation);
            yield return new WaitForSeconds(5f);
        }
    }
}
