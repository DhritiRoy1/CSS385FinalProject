using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class keyMechanics : MonoBehaviour
{
    // init all child objects - keys - in current level
    // rises when you attempt to access a non-static field without the prior creation of an object instance

    List<Collider2D> childKeys = new List<Collider2D>();
    public GameObject player;
    Collider2D collider2DPlayer;
    private bool gotAllKeys = false;

    // ----------------- DISPLAY MECHANIC ------------------------ //
    private int numKeysCollected = 0;
    private int numKeyNotCollected = 0;

    void Awake()
    {
        numKeyNotCollected = transform.childCount;
        // Display "uncollected state" to screen
        
        collider2DPlayer = player.GetComponent<Collider2D>();

        foreach (Transform child in transform)
        {
            childKeys.Add(child.GetComponentInChildren<Collider2D>());
        }
    }

    void Update()
    {
        if (!gotAllKeys)
        {
            foreach (Collider2D keyCollider in childKeys)
            {
                if (keyCollider.IsTouching(collider2DPlayer))
                {
                    Debug.Log("collided key: " + keyCollider.name);

                    // 1. Hide key from display - collected status
                    keyCollider.gameObject.SetActive(false);
                    // 2. Increment collected key amount
                    ++numKeysCollected;
                    // 3. Remove collider2d component from the list
                    childKeys.Remove(keyCollider);

                    if (childKeys.Count == 0)
                    {
                        gotAllKeys = true;
                    }
                }
            }
        }
        // Player collected all keys
        else
        {

        }
        
    }
}
