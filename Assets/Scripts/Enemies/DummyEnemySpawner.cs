using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemySpawner : MonoBehaviour
{
    Vector2 spawnPoint = new Vector2(0, 0);

    [SerializeField] GameObject [] enemies;

    [SerializeField] float timeBetweenEnemies;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("TestEnemies");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TestEnemies()
    {
        foreach (GameObject enemy in enemies) {
            Instantiate(enemy, spawnPoint, Quaternion.identity);
            yield return new WaitForSeconds (timeBetweenEnemies);
        }
        yield break;
    }
}
