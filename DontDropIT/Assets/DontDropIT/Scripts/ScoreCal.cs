using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCal : MonoBehaviour
{
    // The points variable to store the current score
    public int points = 0;

    // The slider variable to reference the GUI slider
    public Slider slider;

    // The maxPoints variable to set the maximum score
    public int maxPoints = 100;

    // The itemTag variable to set the tag of the items
    public string itemTag = "Luggage";

    // The addPoints variable to set the amount of points to add
   // public int addPoints = 10;

    // The deductPoints variable to set the amount of points to deduct
    public int deductPoints = 5;

    // Start is called before the first frame update
    void Start()
    {
        // Find the slider component by its name
        slider = GameObject.Find("Slider").GetComponent<Slider>();

        // Set the slider's max value to the maxPoints
        slider.maxValue = maxPoints;

        // Set the slider's value to the points
        slider.value = points;
    }

    /*// OnTriggerEnter2D is called when a collider enters the trigger zone
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider has the itemTag
        if (other.gameObject.tag == itemTag)
        {
            // Add the addPoints to the points
            points += addPoints;

            // Clamp the points between 0 and maxPoints
            points = Mathf.Clamp(points, 0, maxPoints);

            // Update the slider's value
            slider.value = points;
        }
    }*/

    // OnTriggerExit2D is called when a collider exits the trigger zone
    void OnTriggerExit(Collider other)
    {
        // Check if the collider has the itemTag
        if (other.gameObject.tag == itemTag)
        {
            // Deduct the deductPoints from the points
            points -= deductPoints;

            // Clamp the points between 0 and maxPoints
            points = Mathf.Clamp(points, 0, maxPoints);
            Debug.Log("Luggage -1");
            // Update the slider's value
            slider.value = points;
        }
    }
}
    
