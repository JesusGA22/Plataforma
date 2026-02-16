using UnityEngine;

public class CONTROLANIMACIONES2D : MonoBehaviour
{

    Rigidbody2D rb;
    Animator animator;
    IGrounded2D grounded2D;
    MOVE2D move2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        grounded2D = GetComponentInChildren<IGrounded2D>();
        move2D = GetComponentInChildren<MOVE2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator == null) return;

        if (Mathf.Abs(rb.linearVelocityX) < 0.1)//parado
            animator.SetFloat("velocityX", 0);
        else
        {
            if (move2D)
            {
                if (!move2D.IsRunning)
                    animator.SetFloat("velocityX", 1);//Andando. Animacion va a la velocidad normal
                else
                {
                    animator.SetFloat("velocityX", 2);   //Corriendo. Animacion va al doble de la animacion normal
                }
            }
            else 
            {
                animator.SetFloat("velocityX", 1);
            }
        }

        animator.SetFloat("velocityY", rb.linearVelocityY);
        animator.SetBool("IsGrounded", grounded2D.IsGroundedRaw);
    }
}
