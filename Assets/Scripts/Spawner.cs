using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private bool canSpawn = true;
    //[SerializeField] private float spawnRate;

    [Tooltip("Minimum time between consecutive spawns, in seconds")][SerializeField] float minTimeBetweenSpawns = 1f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")][SerializeField] float maxTimeBetweenSpawns = 3f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawner());
    }

    private IEnumerator spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (canSpawn)
        {
            yield return wait;
            int rand = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyTospawn = enemyPrefabs[rand];

            Instantiate(enemyTospawn, transform.position, Quaternion.identity);
        }
    }
}