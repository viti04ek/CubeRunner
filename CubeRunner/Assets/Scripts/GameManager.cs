using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject EnemyPrefab;
    public Transform Spawner;
    public float SpawnerXMax;

    public Text ScoreText;
    private int _score = 0;


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


    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }


    public void ScoreUp()
    {
        _score++;
        ScoreText.text = _score.ToString();
    }
}
