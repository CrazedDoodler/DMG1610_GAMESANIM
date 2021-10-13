using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && gameManager.hasKey == true);
        {
            print("Door is now unlocked!");
            gameManager.isDoorLocked = false;
        }
        if(other.CompareTag("Player") && gameManager.hasKey == false);
        {
            print("Door is locked... where is that key?");
        }
    }
}
