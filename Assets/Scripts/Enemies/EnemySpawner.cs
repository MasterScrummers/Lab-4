using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] typesOfEnemies; //The types of enemies.
    public float spawningIntervals = 3.3f; //In seconds.

    private Dictionary<string, List<GameObject>> spawnedEnemies; //A dictionary of all the types of enemies hold all the pointers of them.
    private MainGameStartUp startUpRef; //Reference of the main game start up.

    private float spawnTimer;

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
    }

    private void SpawnWave()
    {
        switch (startUpRef.stage)
        {
            case 1:
                SpawnEnemy(2);
                return;
            case 2:
                return;
            case 3:

                return;
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
                enemy.GetComponent<EnemyBehaviour>().Reset();
                return;
            }
        }
        spawnedEnemies[enemyName].Add(Instantiate(typesOfEnemies[index]));
    }
}
