using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public PickupType type;
    public int value;

    [Header("Bobbing Motion")]
    private Vector3 startPos;
    public float rotationSpeed;
    public float bobSpeed;
    public float bobHeight;
    private bool bobbingUp;

    public AudioClip pickupSFX;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    public enum PickupType
    {
        Health,
        Ammo
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerControl player = other.GetComponent<PlayerControl>();

            switch(type)
            {
                case PickupType.Health:
                player.GiveHealth(value);
                break;
                case PickupType.Ammo:
                player.GiveAmmo(value);
                break;
                default:
                print("Type not accepted");
                break;

            }
            other.GetComponent<AudioSource>().PlayOneShot(pickupSFX);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        Vector3 offset = (bobbingUp == true ? new Vector3(0, bobHeight / 2, 0) : new Vector3(0, -bobHeight, 0));
        transform.position = Vector3.MoveTowards(transform.position, startPos + offset, bobSpeed * Time.deltaTime);
        if(transform.position == startPos + offset)
            bobbingUp = !bobbingUp;
    }
}
