using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 20.0f;
    public float hInput;
    public float vInput;

    // public float health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    hInput = Input.GetAxis("Horizontal") 
    vInput = Input.GetAxis("Vertical")   

    transform.Translate(Vector3.right * speed * hInput * Time.deltaTime);
    transform.Translate(Vector3.up * speed * vInput * Time.deltaTime);
// Create wall on -x sides
    if(transform.position.x < -xRange)
    {
        transform.position = new Vector3(-xrange, transform.position.y, transform.position.z);
    }
// Create wall on x sides
    if(transform.position.x < -xRange)
    {
        transform.position = new Vector3(-xrange, transform.position.y, transform.position.z);
    }

    }
}
