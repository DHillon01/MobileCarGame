using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
  public Level_items levelItems; // Reference to the scriptable object holding object prefabs

    public Transform spawnPosition; // Position to spawn objects

    public float spawnRate = 1f; // Rate of spawning
    private float spawnTimer = 0f;
    public float deactivate_time;
    private void Update()
    {
        // Check if it's time to spawn
        if (Time.time >= spawnTimer)
        {
            SpawnObject();
            spawnTimer = Time.time + spawnRate; // Set the next spawn time
        }
    }

    private void SpawnObject()
    {
        // Get a random object prefab from the LevelItems scriptable object
        GameObject objectPrefab = levelItems.GetRandomObjectPrefab();

        if (objectPrefab != null)
        {
            // Instantiate the object at the spawn position
            Instantiate(objectPrefab, spawnPosition.position, Quaternion.identity);

            // Destroy the spawned object after a delay
           // StartCoroutine(DestroyObjectAfterDelay(spawnedObject, deactivate_time));
        }
    }
/*
    private IEnumerator DestroyObjectAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }*/
}
