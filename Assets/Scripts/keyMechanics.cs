using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;

public class keyMechanics : MonoBehaviour
{
    // init all child objects - keys - in current level
    // rises when you attempt to access a non-static field without the prior creation of an object instance

    List<Collider2D> childKeys = new List<Collider2D>();
    List<GameObject> iconKeys = new List<GameObject>();
    public GameObject player;
    Collider2D collider2DPlayer;
    private bool gotAllKeys = false;
    private bool gameCleared = false;
    public Sprite spriteKeyIcon;
    public float xOffset;
    public Vector3 UIOffset;
    private AudioSource audioSource;
    public GameObject nextLevelDoor;
    

    // ----------------- DISPLAY MECHANIC ------------------------ //
    private int numKeysCollected = 0;

    void Awake()
    {
        int count = 0;
        UIOffset = new Vector3(3.64f,2.55f,-1.0f);

        collider2DPlayer = player.GetComponent<Collider2D>();

        foreach (Transform child in transform)
        {
            childKeys.Add(child.GetComponentInChildren<Collider2D>());
            iconKeys.Add(new GameObject("keyIcon" + count.ToString()));
            count++;
        }

        foreach(GameObject icons in iconKeys)
        {
            icons.AddComponent<SpriteRenderer>();
            SpriteRenderer sr = icons.GetComponent<SpriteRenderer>();
            sr.sprite = spriteKeyIcon;
            // black for uncollected
            sr.color = Color.black;
            // always on right corner of camera + include on Update()
            icons.transform.position = player.transform.position + UIOffset + (Vector3.right * xOffset);
            xOffset += 0.2f;
        }
        xOffset += 0.0f;

        audioSource = GetComponent<AudioSource>();
        nextLevelDoor.GetComponent<doorBehavior>().enabled = false;
        
    }

    void Update()
    {
        // UI mechanic
        foreach (GameObject icons in iconKeys)
        {
            icons.transform.position = player.transform.position + UIOffset + (Vector3.right * xOffset);
            xOffset += 0.2f;
        }
        xOffset = 0.0f;
        if (!gotAllKeys && !gameCleared)
        {
            foreach (Collider2D keyCollider in childKeys)
            {
                if (keyCollider.IsTouching(collider2DPlayer))
                {
                    Debug.Log("collided key: " + keyCollider.name);

                    // Hide key from display - collected status
                    keyCollider.gameObject.SetActive(false);

                    iconKeys[numKeysCollected].GetComponent<SpriteRenderer>().color = Color.yellow;
                    numKeysCollected++;

                    // Remove collider2d component from the list - it throws exception because I am
                    // removing the collider during iteration.
                    childKeys.Remove(keyCollider);
                    if (childKeys.Count == 0)
                    {
                        gotAllKeys = true;
                    }
                }
            }

            
        }
        // Player collected all keys
        else if (gotAllKeys && !gameCleared)
        {
            Debug.Log("clear");
            // play door opening sound
            audioSource.Play();
            nextLevelDoor.GetComponent<SpriteRenderer>().color = Color.black;
            nextLevelDoor.GetComponent<doorBehavior>().enabled = true;
            gameCleared = true;
        }
        
    }
}
