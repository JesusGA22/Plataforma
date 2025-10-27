using UnityEngine;

public class RUN2D : MonoBehaviour
{
    //variable inspector
    [SerializeField] float runSpeed=5f;

    //variables internas
    float inputX;

    //Referencia a componente
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //capturo el 
        inputX = Input.GetAxis("Horizontal");
        //

    }

    private void FixedUpdate()
    {
        rb.linearVelocityX= inputX*runSpeed;
    }
}
