using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float distanceFromPlayer = 0.0f;
    [SerializeField]private float distanceToSpawn = 10.0f;
    [SerializeField]private float numberToSpawn = 10.0f;
    [SerializeField]private Transform playersTransform;
    [SerializeField]private float spawnRange = 0.0f;
    [SerializeField]private List<GameObject> enemysToSpawn;

    void Update()
    {
        distanceFromPlayer = getDistanceFromPlayer();
        if(distanceFromPlayer <= distanceToSpawn)
        {
            for (int i = 0; i < (numberToSpawn - 1); i++)
            {
                Instantiate(enemysToSpawn[0], getRandomPosition(), Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
    }

    private Vector3 getRandomPosition()
    {
        float x = transform.position.x + Random.Range(-spawnRange, spawnRange);
        float y = 0.5f;
        float z = transform.position.z + Random.Range(-spawnRange, spawnRange);
        return new Vector3(x,y,z);
    }

    private float getDistanceFromPlayer()
    {
        return Vector3.Distance(transform.position, playersTransform.position);
    }
}
