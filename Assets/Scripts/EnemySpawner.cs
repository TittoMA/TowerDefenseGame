using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float minTime, maxTime;
    public float minPosX, maxPosX;
    
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        Instantiate(enemy, new Vector3(Random.Range(minPosX, maxPosX), transform.position.y, transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        
        StartCoroutine(SpawnEnemy());
    }
}
