using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMover : MonoBehaviour
{
   
    // Declare the variables for drag and throw logic
    private GameObject throwGameObject;
    private Rigidbody rb;
    private Plane plane;
    private Vector3 offset;
    private Vector3 velocity;
    private bool isDragging;
    private bool isThrown;
    private float timeDown, timeUp, timeInterval;
    [SerializeField]private float Xaxis,Yaxis,Zaxis;
    [SerializeField] private bool isTrail;
    public bool inTheZone;
    private TrailRenderer trailRenderer;
    private void Start()
    {
        
    }
    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Call the OnMouseDown logic
            OnMouseDown();
        }

        // Check if the left mouse button is held
        if (Input.GetMouseButton(0))
        {
            // Call the OnMouseDrag logic
            OnMouseDrag();
        }

        // Check if the left mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            // Call the OnMouseUp logic
            OnMouseUp();
        }
    }

    void OnMouseDown()
    {
        // Get the mouse position
        Vector3 mousePosition = Input.mousePosition;

        // Create a ray from the mouse position to the scene
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        // Check if the ray hits the object
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.tag == "Luggage")
            {
                timeDown = Time.time;
                // Get the object and its rigidbody
                throwGameObject = hit.collider.gameObject;
                trailRenderer = throwGameObject.GetComponent<TrailRenderer>();
                rb = throwGameObject.GetComponent<Rigidbody>();
                // Set the object's kinematic state to true
                rb.isKinematic = true;

                // Create a plane parallel to the camera's near plane
                plane = new Plane(Camera.main.transform.forward, throwGameObject.transform.position);

                // Get the distance from the ray to the plane
                float distance;
                plane.Raycast(ray, out distance);

                // Get the point on the plane where the ray hits
                Vector3 planePoint = ray.GetPoint(distance);

                // Get the offset of the object from the plane point
                offset = throwGameObject.transform.position - planePoint;
                lineOn();
                // Set the dragging flag to true
                isDragging = true;
            }
        }
    }
    void OnMouseDrag()
    {
        // Check if the object is being dragged
        if (isDragging)
        {
            // Get the mouse position
            Vector3 mousePosition = Input.mousePosition;
            
            // Create a ray from the mouse position to the scene
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            // Get the distance from the ray to the plane
            float distance;
            plane.Raycast(ray, out distance);

            // Get the point on the plane where the ray hits
            Vector3 planePoint = ray.GetPoint(distance);

            // Calculate the new velocity based on the change in position over time
            velocity = (planePoint - throwGameObject.transform.position) ;

            // Move the object to the new position
          //  throwGameObject.transform.position = planePoint;
        }
    }


    void OnMouseUp()
    {
        // Check if the object is being dragged
        if (isDragging)
        {
            timeUp = Time.time;
            timeInterval = timeDown - timeUp;
            // Set the object's kinematic state to false
            rb.isKinematic = false;

            // Apply the velocity to the object's rigidbody
            rb.velocity = velocity;
            rb.AddForce(velocity.x * Xaxis, velocity.y * Yaxis, -velocity.z * Zaxis/timeInterval,ForceMode.Force);
            // Set the dragging flag to false
            isDragging = false;
            Invoke("lineOff", 2f);
            // Set the thrown flag to true
            isThrown = true;
        }
    }

    public void lineOn( )
    {
        trailRenderer.enabled = true;
    }
    
    public void lineOff( )
    {
        trailRenderer.enabled = false;

    }

    //object poolig clone etc

}
