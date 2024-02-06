using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    // Reference the scriptable object
    public Level_items level_Items;

    // Declare the spawn rate, position, and timer
    public float spawnRate = 1f;
    public Transform spawnPosition;
    private float spawnTimer;
    public bool IsSpawn;
    void Update()
    {
        Spwan();
    }

    private void Spwan()
    {

        if (!IsSpawn) { }

        else
        {

            // Update the spawn timer
            spawnTimer += Time.deltaTime;
            // Check if the spawn timer reaches the spawn rate
            if (spawnTimer >= spawnRate)
            {
                // Reset the spawn timer
                spawnTimer = 0f;

                // Get a random index from the array list
                int index = Random.Range(0, level_Items.gameObjects.Length);

                // Get the game object at the index
                GameObject item = level_Items.gameObjects[index];

                // Instantiate the game object at the spawn position
                Instantiate(item, spawnPosition.position, Quaternion.identity);
            }
        }
    }
}

