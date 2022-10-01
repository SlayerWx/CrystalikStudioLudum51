using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipEnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    float enemyHeight;

    private Vector2 screenBounds;

    [SerializeField] float timeBetweenSpawning;
    [SerializeField] int enemiesPerSpawn = 2;
    float timeCounter;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        enemyHeight = enemyPrefab.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter -= Time.deltaTime;

        if (timeCounter < 0)
        {
            StartCoroutine(SpawnEnemiesCoroutine());
        }
    }

    IEnumerator SpawnEnemiesCoroutine()
    {
        SpawnEnemy();
        yield return new WaitForSeconds(0.2f);
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        float randomPosX = Random.Range(-screenBounds.x, screenBounds.x);
        Vector3 spawnPoint = new Vector3(randomPosX, screenBounds.y + enemyHeight);
        Instantiate(enemyPrefab, spawnPoint, Quaternion.identity, transform.parent);
        timeCounter = timeBetweenSpawning;
    }
}
