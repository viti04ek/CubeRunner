using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject EnemyPrefab;
    public Transform Spawner;
    public float SpawnerXMax;


    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    
    void Start()
    {
        StartCoroutine("SpawnEnemies");
    }


    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.8f);
            Spawn();
        }
    }


    public void Spawn()
    {
        float randomSpawnX = Random.Range(-SpawnerXMax, SpawnerXMax);
        Vector3 enemySpawnPos = Spawner.position;
        enemySpawnPos.x = randomSpawnX;

        Instantiate(EnemyPrefab, enemySpawnPos, Quaternion.identity);
    }
}
