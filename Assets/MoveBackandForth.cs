using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackandForth : MonoBehaviour
{
    public float backForwardControl;
    
    public bool jumpingControl;
    public bool leftControl;
    public bool rightControl;
    public float playerSpeed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        backForwardControl = Input.GetAxis("Horizontal");
        jumpingControl = Input.GetButton("Jump");

   
        transform.Translate(Vector3.right * Time.deltaTime * backForwardControl * playerSpeed);

        if (leftControl)
        {
            transform.Rotate(0f, 180f, 0f);
        }
        else if (rightControl)
        {
            transform.Rotate(0f, 180f, 0f);
        }

        if (jumpingControl)
        {
            transform.Translate(new Vector3(3, 1, 0) * Time.deltaTime * 5);
        }


        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "gold")
        {
            collision.gameObject.SetActive(false);
        }
    }

}
