using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // WASD control

    // AD and left/right
    Vector2 forwardBackInput;
    bool changeDirection;
    public float playerRunSpeed = 2.5f;
    private Animator animator;
  
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Flip sprite across Y-axis
        if (changeDirection)
        {
            Vector3 scale = transform.localScale;
            scale.y *= -1;
            transform.localScale = scale;
        }

        // Move Left / Right
        forwardBackInput.x = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * forwardBackInput.x * playerRunSpeed);

        if (forwardBackInput.x != 0)
        {
            animator.ResetTrigger("Idle");
            animator.SetTrigger("Run");
        }
        else
        {
            animator.ResetTrigger("Run");
            animator.SetTrigger("Idle");
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow))
        {

        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.RightArrow))
        {

        }
    
        
    }
}
