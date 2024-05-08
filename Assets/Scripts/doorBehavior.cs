using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorBehavior : MonoBehaviour
{
    private bool isTouching = false;
    
    public GameObject player;

    public GameObject doorEnterTextBox;
    private bool textBoxOnScreen = false;

    public Vector3 textBoxOffset = new Vector3(0.4f, 0.27f, -0.1f);
    // Start is called before the first frame update
    void Start()
    {
        doorEnterTextBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (textBoxOnScreen)
        {
            doorEnterTextBox.transform.position = player.transform.position + textBoxOffset;
            // make it appear it for 3 seconds, then deactivate
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            Debug.Log("E is pressed");
            if (isTouching)
            {
                if (tag == "doorenter")
                {
                    // display message
                    doorEnterTextBox.transform.position = player.transform.position + textBoxOffset;
                    doorEnterTextBox.SetActive(true);
                    textBoxOnScreen = true;
                }
                else if (tag == "doorLevel1")
                {

                }
                else if (tag == "doorLevel2")
                {

                }
                

            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("is touching");
        if (other.gameObject.tag == "Player")
        {
            isTouching = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTouching = false;
        }
            
    }
    

}
