using UnityEngine;
using UnityEngine.Events;

public class JUMP2D : MonoBehaviour

{
    public float force = 5f;
    private Rigidbody2D rb;
    private bool jumpkey;
    private IGrounded2D _grounded;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _grounded.IsGrounded)
        {
            jumpkey = true;
        }
    }
    private void FixedUpdate()
    {
        if (jumpkey)
        {
            jumpkey = false;
            //rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            rb.linearVelocityY = force;
            OnJump.Invoke();
        }
    }
   

}
