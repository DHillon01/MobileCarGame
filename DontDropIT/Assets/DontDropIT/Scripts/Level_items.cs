using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  [CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData", order = 1)]

public class Level_items : ScriptableObject
{

    
    public  GameObject[] gameObjects;
    public GameObject GetRandomObjectPrefab()
    {
        if (gameObjects.Length == 0)
        {
            Debug.LogError("No objects defined in the Level_items scriptable object.");
            return null;
        }

        // Get a random index within the array length
        int randomIndex = Random.Range(0, gameObjects.Length);

        // Return the prefab at the random index
        return gameObjects[randomIndex];
    }
}

   

