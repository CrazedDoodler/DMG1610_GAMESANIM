using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float lifetime;
    private float shootTime;

    void OnEnable()
    {
        shootTime = Time.time;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            other.GetComponent<PlayerControl>().TakeDamage(damage);
        else if(other.CompareTag("Enemy"))
            other.GetComponent<EnemyAI>().TakeDamage(damage);

        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - shootTime >= lifetime)
            gameObject.SetActive(false);
    }
}
