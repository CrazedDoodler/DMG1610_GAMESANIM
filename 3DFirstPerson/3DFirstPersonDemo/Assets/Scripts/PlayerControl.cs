using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float lookSensitivity;
    public float maxLookX;
    public float minLookX;
    private float rotX;
    private Camera camera;
    private Rigidbody rb;
    private WeaponReady weapon;
//Move in unit per sec
//force upwards
//Mouse Look Sensitive
//Lowest down
//Highest up
//Current x rotate

    void Awake()
    {
        weapon = GetComponent<WeaponReady>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //get components
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();
        
        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
                weapon.Shoot();
        }
    }

    void FixedUpdate()
    {
        if(Input.GetButtonDown("Jump"))
            Jump();
    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        // rb.velocity = new Vector3(x, rb.velocity.y, z);
        Vector3 dir = transform.right * x + transform.forward * z;
        rb.velocity = dir;
    }

    void CamLook()
    {
        float y =Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        camera.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, 1.1f))
            rb.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
    }
}

