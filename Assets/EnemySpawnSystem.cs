using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSystem : MonoBehaviour
{
    public GameObject[] Enemys;

    public List<GameObject> activeEnemys = new List<GameObject>();

    public float maxEnemys;

    public GameObject[] spawnLocations;

    public float spawnInterval;
    float maxSpawnInterval;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxSpawnInterval = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        spawnInterval -= 1 * Time.deltaTime;
        if (spawnInterval <= 0 && activeEnemys.Count <= maxEnemys)
        {
            spawnEnemy();
        }
    }

    void spawnEnemy()
    {
        int enemySlelected = Random.Range(0, Enemys.Length);

        int spawnLocation = Random.Range(0, spawnLocations.Length);

        GameObject newEnemy = Instantiate(Enemys[enemySlelected], spawnLocations[spawnLocation].transform.position, Quaternion.identity);

        spawnInterval = maxSpawnInterval;

        activeEnemys.Add(newEnemy);
    }
}
