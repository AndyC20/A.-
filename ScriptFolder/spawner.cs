using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // select the prefab
    public int maxSpawnCount = 10; // Maximum number of objects to spawn

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        List<Transform> childPoint = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        childPoint.Remove(transform); // Remove the parent from the possible positions

        int Remaining = Mathf.Min(maxSpawnCount, childPoint.Count);

        for (int i = 0; i < Remaining; i++) // loop spawn until 10 prefabs are spawn
        {
            int randomChildIndex = Random.Range(0, childPoint.Count); //Select spawn point at random
            Transform randomChild = childPoint[randomChildIndex];
            Vector3 spawnPosition = randomChild.position;
            Quaternion spawnRotation = randomChild.rotation;

            Instantiate(prefabToSpawn, spawnPosition, spawnRotation); //spawn the prefab in the location 

            childPoint.RemoveAt(randomChildIndex); //remove the point used
        }
    }
}

