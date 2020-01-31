using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _coinsPrefab;

    [SerializeField]
    private GameObject _coinsContainer;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoinsRoutine());
    }

    // Spawn an enemy every 5 seconds.
    // while loop -> infinite loop that keeps going until the game ends.
    IEnumerator SpawnCoinsRoutine()
    {
        while (_stopSpawning == false)
        {
            float x = Random.Range(-8f, 8f);
            Vector3 spawnPos = new Vector3(x, 8f, 0);

            GameObject newCoins = Instantiate(_coinsPrefab, spawnPos, Quaternion.identity);
            newCoins.transform.SetParent(_coinsContainer.transform);

            // wait for 0.5 seconds
            yield return new WaitForSeconds(5f);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
