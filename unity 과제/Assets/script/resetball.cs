using UnityEngine;

public class Ball : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.name.ToLower().Contains("ground"))
        {
            
            Destroy(gameObject);
        }
    }
}