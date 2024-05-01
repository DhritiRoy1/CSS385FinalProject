using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // WASD control

    // AD and left/right
    public Vector2 forwardBackInput;
    public Vector2 jumpingInput;
    public float playerRunSpeed = 2.5f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
  
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move Left / Right
        forwardBackInput.x = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * forwardBackInput.x * playerRunSpeed);

        // Jumping
        jumpingInput.y = Input.GetAxis("Jump");
        transform.Translate(Vector2.up * Time.deltaTime * jumpingInput * 3.0f);

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

        // determine when to flip the sprite
        // if moving left but facing right, flip the sprite
        if (forwardBackInput.x < 0 && !spriteRenderer.flipX)
        {
            spriteRenderer.flipX = true;
        }
        // if moving right but not facing right, flip the sprite
        else if (forwardBackInput.x > 0 && spriteRenderer.flipX)
        {
            spriteRenderer.flipX = false;
        }
    
        
    }
}
