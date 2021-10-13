using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLock : MonoBehaviour
{
    public string pickup;

    public int amount;

    public GameManager gameManager;

    void Update()
    {
        transform.Rotate(Vector3.back * 2 * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("You got a Gold Key! Head to the Door!");
        gameManager.hasKey = true;
        Destroy(gameObject);
    }
}