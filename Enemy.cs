using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    public float lives = 3.0f;
    //private Rigidbody2D enemyRb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        //enemyRb.AddForce(lookDirection * speed);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        
    }
    
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy")){
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("Harpoon") ){
            Destroy(collision.gameObject);
        lives = lives-1;
        if(lives <= 0){
            Destroy(gameObject);
        }
        
        }
        if(gameObject.CompareTag("boss")){
            if(lives <= 0){
                SceneManager.LoadScene("W");
            }
        }
        
        
        
    }
}

