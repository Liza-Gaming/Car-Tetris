using System.Collections;
using UnityEngine;

/// A component for spawning enemy game objects at random intervals and positions. 
public class Spawner : MonoBehaviour
{
    /// Prefabs of enemies to spawn.
    [SerializeField] private GameObject[] enemyPrefabs;

    /// Flag indicating whether spawning is enabled.
    [SerializeField] private bool canSpawn = true;

    /// The rate at which enemies are spawned.
    [SerializeField] private float spawnRate;

    /// Minimum time between consecutive spawns, in seconds.
    [Tooltip("Minimum time between consecutive spawns, in seconds")]
    [SerializeField] private float minTimeBetweenSpawns = 0.5f;

    /// Maximum time between consecutive spawns, in seconds.
    [Tooltip("Maximum time between consecutive spawns, in seconds")]
    [SerializeField] private float maxTimeBetweenSpawns = 1.5f;

    /// Initializes the spawning coroutine.
    void Start()
    {
        StartCoroutine(SpawnerCoroutine());
    }

    /// Coroutine for handling enemy spawning.
    private IEnumerator SpawnerCoroutine()
    {
        while (canSpawn)
        {
            float timeBetweenSpawnsInSeconds = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawnsInSeconds);

            // Select a random enemy prefab to spawn.
            int rand = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[rand];

            // Instantiate the enemy at the spawner's position.
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }
}