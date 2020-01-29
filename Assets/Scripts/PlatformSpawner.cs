using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _enemyContainer;

        [SerializeField]
    private GameObject _enemyplatformPrefab;

    [SerializeField]
    private GameObject _enemyplatformContainer;

    [SerializeField]
    private float _spawnTimer;

    [SerializeField]
    private float _enemyplatformspawnTimer;

    private bool _stopSpawning = false;

void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnEnemyplatformRoutine());
    }

IEnumerator SpawnEnemyRoutine()
    {
        while(_stopSpawning == false )
        {
            Vector3 spawnPos = new Vector3(Random.Range(-3.7f, 3.7f), transform.position.y, 0);

            GameObject newEnemy = Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
            newEnemy.transform.SetParent(_enemyContainer.transform);

            // wait for 5 seconds
            yield return new WaitForSeconds(_spawnTimer);
        }
    }

IEnumerator SpawnEnemyplatformRoutine()
    {
        while(_stopSpawning == false )
        {
            Vector3 spawnPos = new Vector3(Random.Range(-3.7f, 3.7f), transform.position.y, 0);

            GameObject newEnemyplatform = Instantiate(_enemyplatformPrefab, spawnPos, Quaternion.identity);
            newEnemyplatform.transform.SetParent(_enemyplatformContainer.transform);

            // wait for 5 seconds
            yield return new WaitForSeconds(_enemyplatformspawnTimer);
        }
    }

    public void OnPlayerDeath()
    {
    _stopSpawning = true;
    }
}
