using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitButton : MonoBehaviour
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
            Application.Quit();
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
