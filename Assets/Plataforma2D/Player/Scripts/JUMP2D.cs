using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class JUMP2D : MonoBehaviour

{
    //Referencia a componente
    StatsComponent statsComponent;
    Rigidbody2D rb;
    private bool jumpkey;
    private IGrounded2D _grounded;
    private float saltoExtra;

    //variables par aver si esta en el suelo
    LayerMask groundMask;


    //eventos
    public UnityEvent OnJump;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //inicializacion de varianle 
        groundMask = LayerMask.GetMask("Ground");
        rb = GetComponent<Rigidbody2D>();
        _grounded = GetComponentInChildren<IGrounded2D>();
        jumpkey = false;
        statsComponent = GetComponent<StatsComponent>();
        saltoExtra = statsComponent.stats.saltosExtra;
    }

    // Update is called once per frame
    public void Jump(InputAction.CallbackContext context = default)
    {
        if (_grounded.IsGroundedRaw || saltoExtra > 0)
        {
            jumpkey = true;
            saltoExtra--;
            if (_grounded.IsGroundedRaw)
            {
                saltoExtra = statsComponent.stats.saltosExtra;
            }
        }
    }
    private void FixedUpdate()
    {
        if (jumpkey)
        {
            jumpkey = false;
            //rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            rb.linearVelocityY = statsComponent.stats.jumpForce;
            OnJump.Invoke();
        }
        if (rb.linearVelocityY < 0.1 && rb.linearVelocityY < statsComponent.stats.velocidadMax)
        {
            rb.linearVelocityY *= statsComponent.stats.fuerzaCaida;
        }
    }
   

}
