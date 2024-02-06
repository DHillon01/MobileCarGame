using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColliderCheck : MonoBehaviour
{

    // The distance of the ray
    public float rayDistance = 5f;

    // The layer mask for the border wall collider layer
    public LayerMask borderWallLayer;
    
    // The size of the car's box collider
    public Vector2 carSize ;
    private void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        carSize = transform.position;

        ShootRay(carSize, carSize.y / 2f); // Left
        ShootRay(carSize, carSize.x / 2f); // Right
    }

    // Shoot a ray from the car in a given direction and offset
    void ShootRay(Vector2 direction, float offset)
    {
        // Calculate the origin of the ray
        Vector2 origin = (Vector2)transform.position + direction * offset;

        // Draw the ray for debugging purposes
        Debug.DrawRay(origin, direction * rayDistance, Color.red);

        // Check if the ray hits anything
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, rayDistance, borderWallLayer);

        // If the ray hits the border wall collider layer
        if (hit.collider != null)
        {
            // Print a message to the console
            Debug.Log("Gonna hit the wall!");
        }
    }
}


