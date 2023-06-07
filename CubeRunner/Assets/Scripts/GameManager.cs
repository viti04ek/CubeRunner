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

    private bool _gameStarted = false;

    public GameObject MainMenu;

    private int _highScore = 0;
    public Text HightScoreText;


    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    private void Start()
    {
        if (PlayerPrefs.HasKey("_highScore"))
            _highScore = PlayerPrefs.GetInt("_highScore");
        
        HightScoreText.text = $"High score: {_highScore}";
    }


    private void Update()
    {
        if (Input.anyKeyDown && !_gameStarted)
        {
            _gameStarted = true;
            MainMenu.SetActive(false);
            ScoreText.gameObject.SetActive(true);
            StartCoroutine("SpawnEnemies");
        }
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
        if (_score > _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("_highScore", _highScore);
        }

        SceneManager.LoadScene("Game");
    }


    public void ScoreUp()
    {
        _score++;
        ScoreText.text = _score.ToString();
    }
}
