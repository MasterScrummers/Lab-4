using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] typesOfEnemies; //The types of enemies.
    public float spawningIntervals = 3.3f; //In seconds.

    private Dictionary<string, List<GameObject>> spawnedEnemies; //A dictionary of all the types of enemies hold all the pointers of them.
    private MainGameStartUp startUpRef; //Reference of the main game start up.

    private float spawnTimer;
    public float bossCounter = 180.0f;
    private bool bossSpawned = false;

    void Start()
    {
        spawnedEnemies = new Dictionary<string, List<GameObject>>();
        foreach (GameObject type in typesOfEnemies)
        {
            spawnedEnemies.Add(type.name, new List<GameObject>());
        }
        startUpRef = GetComponent<MainGameStartUp>();
        spawnTimer = spawningIntervals;
    }

    void Update()
    {
        if ((spawnTimer -= Time.deltaTime) <= 0)
        {
            spawnTimer = spawningIntervals;
            SpawnWave();
        }

        if (startUpRef.stage == 3)
        {
            bossCounter -= Time.deltaTime;
        }
    }

    private void SpawnWave()
    {
        switch (startUpRef.stage)
        {
            case 1:
                StartCoroutine(SpawnControl(1));
                return;
            case 2:
                StartCoroutine(SpawnControl(2));
                return;
            case 3:
                StartCoroutine(SpawnControl(3));
                return;
        }
    }

    private IEnumerator SpawnControl(int stage)
    {
        if (stage == 1)
        {
            for (int i = 0; i < Random.Range(1, 4); i++)
            {
                SpawnEnemy(0);
            }
            yield return new WaitForSecondsRealtime(Random.Range(2, 5));
            SpawnEnemy(3);
        }

        if (stage == 2)
        {
            for (int i = 0; i < Random.Range(1, 4); i++)
            {
                SpawnEnemy(Random.Range(3, 5));
            }
            yield return new WaitForSecondsRealtime(Random.Range(1, 4));
            for (int i = 0; i < Random.Range(3, 5) ; i++)
            {
                SpawnEnemy(0);
            }
        }

        if (stage == 3)
        {
            if (bossCounter >= 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    SpawnEnemy(0);
                }

                for (int i = 0; i < 2; i++)
                {
                    SpawnEnemy(3);
                }
            }

            if (bossCounter <= 0 && !bossSpawned)
            {
                SpawnEnemy(5);
                bossSpawned = true;
            }
        }
            
    }
    private void SpawnEnemy(int index)
    {
        string enemyName = typesOfEnemies[index].name;
        foreach (GameObject enemy in spawnedEnemies[enemyName])
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);
                enemy.GetComponent<EnemyBehaviour>().ResetValues();
                return;
            }
        }
        spawnedEnemies[enemyName].Add(Instantiate(typesOfEnemies[index]));
    }
}
