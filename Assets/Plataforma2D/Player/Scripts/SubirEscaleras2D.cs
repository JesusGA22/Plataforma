using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;


public class SubirEscaleras2D : MonoBehaviour
{
    //variables interna
    private bool escalando;
    private float gravedadInicial;

    Vector2 input;

    //referencia a los componentes del personaje
    
    StatsComponent statsComponent;
    Rigidbody2D rb;
    BoxCollider2D colision;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //inicializamos variables
        rb = GetComponent<Rigidbody2D>();
        statsComponent = GetComponent<StatsComponent>();
        colision = GetComponent<BoxCollider2D>();
        gravedadInicial = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Escalar()
    {
        var stats = statsComponent.stats;
        float currentVelY = rb.linearVelocityY;

        if ((currentVelY != 0 || escalando) && (colision.IsTouchingLayers(LayerMask.GetMask("escaleras"))))
        {
            rb.linearVelocityY = statsComponent.stats.velocidadSubida;
            rb.gravityScale = 0;
            escalando = true;
        }
        else
        {
            rb.gravityScale = gravedadInicial;
            escalando= false;
        }
        
    }
    private void FixedUpdate()
    {
        Escalar();
    }
}
