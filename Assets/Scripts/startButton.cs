using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Color hoverColor = new Color (0.5f, 0.5f, 0.5f, 1.0f);
    Color origColor;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        origColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {   
        // click
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("TutorialScene");
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
