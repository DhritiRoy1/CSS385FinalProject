using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor.SceneManagement;

public class transitionSceneTextBubbles : MonoBehaviour
{
    public GameObject fadeEffect;
    public Vector3 nextButtonOffset = new Vector3(0.0f, -0.3f, 0);
    private int index = 0;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    
    GameObject[] textBoxes = new GameObject[4];

    private bool dialogueStart = false;
    SpriteRenderer spriteRenderer;
    SpriteRenderer spriteRenderer1;
    Color color;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = fadeEffect.GetComponent<SpriteRenderer>();
        spriteRenderer1 = GetComponent<SpriteRenderer>();
        color.a = 0.0f;
        spriteRenderer1.color = color;

        textBoxes[0] = text1;
        textBoxes[0].SetActive(false);
        textBoxes[1] = text2;
        textBoxes[1].SetActive(false);
        textBoxes[2] = text3;
        textBoxes[2].SetActive(false);
        textBoxes[3] = text4;
        textBoxes[3].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueStart)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (index == 3)
                {
                    SceneManager.LoadScene("tutorialScene");
                    // close current scene
                    return;
                }
                textBoxes[index].SetActive(false);
                index++;
                textBoxes[index].SetActive(true);
                transform.position = textBoxes[index].transform.position + nextButtonOffset;
            }
        }

        else if (spriteRenderer.color.a < 0.1f)
        {
            // start dialogue scene
            dialogueStart = true;
            textBoxes[index].SetActive(true);
            color.a = 1.0f;
            color = Color.white;
            spriteRenderer1.color = color;
            transform.position = textBoxes[index].transform.position + nextButtonOffset;
        }
    }
}
