using UnityEngine;
using System.Collections;
public class Score : MonoBehaviour
{
    public bool inTheZone;
    public int scoreValue = 10; // Default score value
    public int deactivate_time = 14;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag=="Road") 
        {
            StartCoroutine(DestroyObjectAfterDelay(this.gameObject, deactivate_time));

        }
    }
    
    

    private IEnumerator DestroyObjectAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
}
