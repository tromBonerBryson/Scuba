using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    private float forwardInput;
    public float horizontalInput;
    public float speed = 10.0f;
    public float speed2 = 10.0f;
    public float bottom = -5;
    public float upper = 10;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");

        //Move the vehicle foward
        transform.Translate(Vector2.up * Time.deltaTime * speed2 * forwardInput);
        transform.Rotate(Vector2.up, horizontalInput * Time.deltaTime);
        
        
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed);

         if (transform.position.y < bottom){
            transform.position = new Vector3(transform.position.x, bottom, transform.position.z);
        }
        if (transform.position.y > upper){
            transform.position = new Vector3(transform.position.x, upper, transform.position.z);
        }
        
    }
}
