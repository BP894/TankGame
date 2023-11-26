using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;

    [HideInInspector]
    public float healthMax = 200f;
    [HideInInspector]
    public float healthMin = 100f;

    [HideInInspector]
    public float scaleMax = 1.3f;
    [HideInInspector]
    public float scaleMin = 1f;

    [HideInInspector]
    public float speedMax = 2f;
    [HideInInspector]
    public float speedMin = 1f;

    [HideInInspector]
    public Color strongEnemyColor = Color.red;

    private List<GameObject> enemies = new List<GameObject>();
    private int wave;

    private void Update()
    {
        if(enemies.Count <= 0)
        {
            if (wave <= 3)
            {
                SpawnWave();
            }
        }

        if(wave > 3)
        {
            SceneManager.LoadScene("GameWin");
        }
        UpdateUI();
    }
    private void UpdateUI()
    {
        UIManager.instance.UpdateWaveText(wave, enemies.Count);
    }
    private void SpawnWave()
    {
        wave++;
        int spawnCount = Mathf.RoundToInt(wave * 1f);
        for (int i = 0; i < spawnCount; i++)
        {
            float enemyIntensity = Random.Range(0, 1f);
            CreateEnemy(enemyIntensity);
        }
    }
    private void CreateEnemy(float intensity)
    {
        float health = Mathf.Lerp(healthMin, healthMax, intensity);
        float scale = Mathf.Lerp(scaleMin, scaleMax, intensity);
        float speed = Mathf.Lerp(speedMin, speedMax, intensity);
        Color skinColor = Color.Lerp(Color.white, strongEnemyColor, intensity);

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemy.GetComponent<EnemyDamage>().SetUp(health, speed, scale, skinColor);

        enemies.Add(enemy);
        Debug.Log("Intensity : " + intensity);

        enemy.GetComponent<EnemyDamage>().onDeath += () => enemies.Remove(enemy);
        enemy.GetComponent<EnemyDamage>().onDeath += () => Destroy(enemy);
    }
}
