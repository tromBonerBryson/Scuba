using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private float speed = 1.5f;
    
    //private Rigidbody2D enemyRb;
    private GameObject player;
    // Start is called before the first frame update
    

    // Update is called once per frame
    
    
   private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log("HI");
        
        }
        
    }
        
        
        
}


