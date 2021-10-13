using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public bool hasKey;

  public bool isDoorLocked;

  void Start()
  {
      hasKey = false;
      isDoorLocked = true;
  }

  void Update()
  {
      if(hasKey && !isDoorLocked);
      {
          print("Exit the room. QUICKLY!!!");
      }
  }
}