using System.Text.RegularExpressions;
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
        //0. Accesos rapidos
        var stats = statsComponent.stats;

        bool grounded = grounded2D.IsGroundedRaw;
        bool hasInput = Mathf.Abs(inputX) > 0.1f;// INPUT_DEADZONE

        //1. Aceleracion
        float accel = (hasInput) ? stats.acceleration : stats.deceleration;
        if (!grounded)
        {
            if (hasInput) accel *= stats.airMomentum;// aire + input -> aceleracion
            else accel = 0f; // aire+ sin input -> inercia total (no aceleramos ni frenamos)
        }
        // 2. Velocidad objetivo
        float currentVelX = rb.linearVelocityX;
        
        float maxSpeed = stats.moveSpeed;
        if(isRunning) maxSpeed *= stats.runModifique;

        float targetSpeed = inputX * maxSpeed;

        //Si no hay input cambiamos la velocidad objetivo
        if (!hasInput)
        {
            if (grounded) targetSpeed = 0f; //Suelo + sin input -> ir hacia 0
            else targetSpeed = currentVelX; //Aire + son input -> mantener la velocidad actual(inercia)
        }

        //3. Aplicar cambio
        currentVelX =Mathf.MoveTowards(currentVelX, targetSpeed, accel * Time.fixedDeltaTime);
        rb.linearVelocityX = currentVelX;
        /*//calculo mi velocidad
        float currentSpeed =inputX * statsComponent.stats.moveSpeed;

        if (!grounded2D.IsGroundedRaw) currentSpeed *= statsComponent.stats.airMomentum;
        else if(isRunning) currentSpeed *= statsComponent.stats.runModifique;
        //Aplico la velocidad
        rb.linearVelocityX= currentSpeed;*/
    }
}
