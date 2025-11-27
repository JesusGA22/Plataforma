using UnityEngine;
using UnityEngine.InputSystem;

public class MOVE2D : MonoBehaviour
{
    //variables internas
    float inputX;
    bool isRunning = false;

    //Referencia a componente
    StatsComponent statsComponent;
    Rigidbody2D rb;
    IGrounded2D grounded2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        statsComponent = GetComponent<StatsComponent>();
        grounded2D = GetComponentInChildren<IGrounded2D>();
    }

    public void Move(Vector2 input)
    {
        //capturo el input
        inputX = input.x;
        if (Mathf.Abs(inputX) < 0.1) isRunning = false;
    }

    public void Run(InputAction.CallbackContext context = default)
    {
        isRunning = true;
    }

    public bool IsRunning => isRunning;
    private void FixedUpdate()
    {
        //calculo mi velocidad
        float currentSpeed =inputX * statsComponent.stats.moveSpeed;

        if (!grounded2D.IsGroundedRaw) currentSpeed *= statsComponent.stats.airMomentum;
        else if(isRunning) currentSpeed *= statsComponent.stats.runModifique;
        //Aplico la velocidad
        rb.linearVelocityX= currentSpeed;
    }
}
