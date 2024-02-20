
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreCal : MonoBehaviour
{
    public ScoreManager scoreManager; // Reference to the ScoreManager

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider has the Score script
        Score scoreScript = other.gameObject.GetComponent<Score>();
        if (scoreScript != null)
        {
            int itemScore = scoreScript.scoreValue;
            scoreManager.AddScore(itemScore);
            scoreScript.inTheZone = true;

            Debug.Log("Item added with score: " + itemScore);
        }
    }


void OnTriggerExit(Collider other)
    {
        Score scoreScript = other.gameObject.GetComponent<Score>();
        if (scoreScript != null)
        {
            int itemScore = scoreScript.scoreValue;
            scoreManager.ScoreLost(itemScore);

            Debug.Log("Item dropped  with score: " + itemScore);
        }
        // Check if the collider has the itemTag
       
    }
}
    
