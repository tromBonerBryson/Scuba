using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    
    private float forwardInput;
    public float horizontalInput;
    public float speed = 10.0f;
    public float speed2 = 10.0f;
    public float lower = -5;
    public float top = 10;
    
    public GameObject player;
    public GameObject projectilePrefab;
    public GameObject barrel;
    public bool facingRight = true;
    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");

        //Move the vehicle foward
        transform.Translate(Vector2.up * Time.deltaTime * speed2 * forwardInput);
        transform.Rotate(Vector2.up, horizontalInput * Time.deltaTime);
        
        
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed);
        if(horizontalInput < 0 && facingRight){
            Flip();
        }
        if(horizontalInput > 0 && !facingRight){
            Flip();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, barrel.transform.position, player.transform.rotation);
        }

        if (transform.position.y < lower){
            transform.position = new Vector3(transform.position.x, lower, transform.position.z);
        }
        if (transform.position.y > top){
            transform.position = new Vector3(transform.position.x, top, transform.position.z);
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy")){
            Destroy(gameObject);
            SceneManager.LoadScene("L");
        
        }
        if(collision.gameObject.CompareTag("Fish")){
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Debug.Log("HI");
            SceneManager.LoadScene("L");
        
        }
        
        }

    void Flip(){
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
        speed = -speed;
    }
        
        
        
    }
    
    

