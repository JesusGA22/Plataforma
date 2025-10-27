using UnityEngine;

public class CONTROLANIMACIONES2D : MonoBehaviour
{
    float inputX;
    float inputY;
    Rigidbody2D rb;
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        if (Mathf.Abs(rb.linearVelocityY) > 0.1)
        {
 
                animator.Play("JUMP");
                //animator.Play("FALL");
        }
        else if (Mathf.Abs(rb.linearVelocityX) < 0.1) animator.Play("IDLE");
        else animator.Play("RUN");
        
        
        
    }
}
