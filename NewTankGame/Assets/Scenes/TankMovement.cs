using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    float speed = 3.5f;
    
    float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        turnSpeed = 1.5f;

        print(speed);

        print(turnSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed);
    }
}
