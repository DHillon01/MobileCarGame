using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwipeScript : MonoBehaviour
    

{

	Vector2 startPos, endPos, direction; // touch start position, touch end position, swipe direction
	float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time to sontrol throw force in Z direction
    [SerializeField] private GameObject throw_object;
	[SerializeField]
	float throwForceInXandY = 1f; // to control throw force in X and Y directions

    Vector3 worldPos;
    [SerializeField]
	float throwForceInZ = 50f; // to control throw force in Z direction

	Rigidbody rb;
    [SerializeField]private LayerMask objectLayer;

    private Vector2 initialPosition; // the initial position of the mouse
    private Vector2 lastPosition; // the last position of the mouse
    private Vector3 grabOffset;
    void Start()
	{
	}

	// Update is called once per frame
	void Update () {


        // get the world position of the mouse using the camera

        // if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // cast a ray from the camera to the mouse position
            worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // if the ray hits the object
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.tag == "Luggage")
                {
                    throw_object = hit.collider.gameObject;
                    // set the object's kinematic state to true
                    rb = throw_object.GetComponent<Rigidbody>();

                    rb.isKinematic = true;
                    Debug.Log("object touched");
                    grabOffset = transform.position - worldPos;

                    // getting touch position and marking time when you touch the screen
                    touchTimeStart = Time.time;
                }
               

            }
        }
        // if the left mouse button is held
        if (Input.GetMouseButton(0))
        {
             throw_object.transform.position = worldPos ;

            // move the object to the mouse position plus the of

        }
        /*// if you touch the screen
        if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {

			// getting touch position and marking time when you touch the screen
			touchTimeStart = Time.time;
			startPos = Input.GetTouch (0).position;
		}

		// if you release your finger
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended) {

			// marking time when you release it
			touchTimeFinish = Time.time;

			// calculate swipe time interval 
			timeInterval = touchTimeFinish - touchTimeStart;

			// getting release finger position
			endPos = Input.GetTouch (0).position;

			// calculating swipe direction in 2D space
			direction = startPos - endPos;

			// add force to balls rigidbody in 3D space depending on swipe time, direction and throw forces
			rb.isKinematic = false;
			rb.AddForce (- direction.x * throwForceInXandY, - direction.y * throwForceInXandY, throwForceInZ / timeInterval);

			

		}*/

    }
}
