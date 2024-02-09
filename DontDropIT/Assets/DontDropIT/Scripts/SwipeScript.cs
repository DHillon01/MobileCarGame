using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeScript : MonoBehaviour
{

    Vector2 startPos, endPos, direction; // touch start position, touch end position, swipe direction
    float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time to sontrol throw force in Z direction

    [SerializeField]
    float throwForceInXandY = 1f; // to control throw force in X and Y directions

    [SerializeField]
    float throwForceInZ = 50f; // to control throw force in Z direction

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        

        // if you touch the screen
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)||Input.GetMouseButtonDown(0))
        {

            // getting touch position and marking time when you touch the screen
            touchTimeStart = Time.time;
            startPos = Input.GetTouch(0).position;
        }

        // if you release your finger
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)||Input.GetMouseButtonUp(0))
        {

            // marking time when you release it
            touchTimeFinish = Time.time;

            // calculate swipe time interval 
            timeInterval = touchTimeFinish - touchTimeStart;

            // getting release finger position
            endPos = Input.GetTouch(0).position;

            // calculating swipe direction in 2D space
            direction = startPos - endPos;

            // add force to balls rigidbody in 3D space depending on swipe time, direction and throw forces
            rb.isKinematic = false;
            rb.AddForce(-direction.x * throwForceInXandY, -direction.y * throwForceInXandY, throwForceInZ / timeInterval,ForceMode.Impulse);

            // Destroy ball in 4 seconds
            Destroy(gameObject, 3f);

        }

    }

}
