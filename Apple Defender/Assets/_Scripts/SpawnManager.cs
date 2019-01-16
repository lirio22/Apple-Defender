using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject[] spawner;
    public GameObject[] enemyPrefab;
    public Transform enemyStack;

    private bool canSpawn = true;

    private int enemyType;
    private int spawnerIndex;

    private void Update()
    {
        if(canSpawn)
        {
            StartCoroutine(SpawnDelay(Random.Range(0.5f,2.5f)));
        }
    }

    private IEnumerator SpawnDelay(float waitTime)
    {
        canSpawn = false;
        enemyType = Random.Range(0, enemyPrefab.Length);
        if (enemyType == 1)
        {
            spawnerIndex = Random.Range(0, spawner.Length);
            Instantiate(enemyPrefab[enemyType], new Vector3(spawner[spawnerIndex].transform.position.x, spawner[spawnerIndex].transform.position.y - 0.1f, spawner[spawnerIndex].transform.position.z), Quaternion.identity, enemyStack.transform.parent);
        }
        else
        {
            Instantiate(enemyPrefab[enemyType], spawner[Random.Range(0, spawner.Length)].transform.position, Quaternion.identity, enemyStack.transform.parent);
        }
        yield return new WaitForSeconds(waitTime);
        canSpawn = true;
    }
}
