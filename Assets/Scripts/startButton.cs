using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    bool gameStart = false;
    public GameObject fadeOut;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    Color hoverColor = new Color (0.5f, 0.5f, 0.5f, 1.0f);
    Color origColor;
    // Start is called before the first frame update
    void Start()
    {
        fadeOut.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        origColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetMouseButtonDown(0))
        {
            gameStart = true;
        }
        // click
        if (gameStart)
        {
            // fade out
            fadeOut.SetActive(true);
            // slowly lower volume
            audioSource.volume -= 0.001f;

            if (audioSource.volume == 0)
            {
                SceneManager.LoadScene("transitionScene");
            }
            
        }
    }

    // hover button effect
    void OnMouseOver()
    {
        spriteRenderer.color = hoverColor;
    }

    void OnMouseExit()
    {
        spriteRenderer.color = origColor;
    }
}
