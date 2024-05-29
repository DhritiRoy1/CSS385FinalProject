using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyMechanic : MonoBehaviour
{
    // Called in Key prefab but instantiated by levelController.cs

    public static int numKeysTotal;
    public static int numKeysCollected;

    // keyMechanic.cs will share this global data with UIMechanic.cs
    // UIMechanic.cs will constantly check this value to reflect the values 
    // on the screen
    // But the door animation / functionality will be done on this script

    private bool gotAllKeys = false;
    private bool gameCleared = false;

    public GameObject nextLevelDoor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (numKeysCollected == numKeysTotal)
        {
            // open door
            Debug.Log("Open Door, play sound");
            // play sound
        }
    }
}
