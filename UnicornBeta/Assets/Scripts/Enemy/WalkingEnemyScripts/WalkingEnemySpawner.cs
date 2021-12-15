using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemySpawner : MonoBehaviour
{
    public GameObject[] Object;
    public float spawnTime;
    public float startSpawnTime;
    public Transform[] spawnLocation;

    public void Start()
    {
        StartEnemySpawn();
    }

    [ContextMenu("SpawnEnemies")]
    public void StartEnemySpawn() //calling the Coroutine
    {
        StartCoroutine(EnemySpawn());
    }
    IEnumerator EnemySpawn()
    {
        float tempSpawnTime = spawnTime;
        yield return new WaitForSeconds(startSpawnTime); //putting a time value until enemies start to spawn
        for (int i = 0; i < Object.Length; i++)
        {
            GameObject GO = Instantiate(Object[i], spawnLocation[i % 2].position, Quaternion.identity); //setting the spawn locations on both sides
            if ((i % 2) == 1)
            {
                GO.GetComponent<WalkingEnemy>().SwitchDirection();
            }
            yield return new WaitForSeconds(spawnTime); //having a time value for when the next enemy spawns
            spawnTime /= 1.25f; //decreasing the time between spanws
        }
    }
}
