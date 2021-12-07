using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Stats")]

    public float moveSpeed;
    public float jumpForce;
    public int curHP;
    public int maxHP;
    [Header("Mouse Look")]
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

        GameUI.instance.UpdateHealthBar(curHP, maxHP);
        GameUI.instance.UpdateScoreText(0);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CamLock();
        
        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
                weapon.Shoot();
        }
         if(Input.GetButtonDown("Jump"))
            Jump();
        if(GameManager.instance.gamePaused == true)
            return;
    }

    void FixedUpdate()
    {
       
    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        // rb.velocity = new Vector3(x, rb.velocity.y, z);
        // Move with Camera+Direction
        Vector3 dir = transform.right * x + transform.forward * z;
        rb.velocity = dir;
        // Jump With Direction
        dir.y = rb.velocity.y;
    }

    void CamLock()
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

    public void GiveHealth(int amountToGive)
    {
        curHP = Mathf.Clamp(curHP + amountToGive, 0, maxHP);
        GameUI.instance.UpdateHealthBar(curHP, maxHP);
    }

    public void GiveAmmo(int amountToGive)
    {
        weapon.curAmmo = Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }

    public void TakeDamage(int damage)
    {
        curHP -= damage;

        if(curHP <= 0)
            Death();

        GameUI.instance.UpdateHealthBar(curHP, maxHP);
    }

    void Death()
    {
        GameManager.instance.LoseGame();
    }
}

