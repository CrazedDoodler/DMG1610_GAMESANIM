using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReady : MonoBehaviour
{
    // public GameObject bulletPrefab;
    public ObjectPools bulletPool;
    public Transform muzzle;
    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;
    public float bulletSpeed;
    public float shootRate;
    private float lastShootTime;
    private bool isPlayer;
    public AudioClip shootSFX;
    private AudioSource audioSource;

    void Awake()
    {
        // disable cursor
        Cursor.lockState = CursorLockMode.Locked;

        if(GetComponent<PlayerControl>())
            isPlayer = true;

        audioSource = GetComponent<AudioSource>();
    }

    public bool CanShoot()
    {
        if(Time.time - lastShootTime >= shootRate)
        {
            if(curAmmo > 0 || infiniteAmmo == true)
                return true;
        }

        return false;

    }

    public void Shoot()
    {
        lastShootTime = Time.time;
        curAmmo--;

        //GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = muzzle.position;
        bullet.transform.rotation = muzzle.rotation;

        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;

        if(isPlayer)
        {
            GameUI.instance.UpdateAmmoText(curAmmo, maxAmmo);
        }

        audioSource.PlayOneShot(shootSFX);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
