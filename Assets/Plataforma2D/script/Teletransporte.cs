using UnityEngine;

public class Teletransporte : MonoBehaviour
{
    [SerializeField] string targetTag = "Player";
    [SerializeField] Transform salida;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //poner los mensaje de error por si algo no esta definido
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            collision.GetComponentInParent<PlayerControler>().transform.position = salida.position;
        }
    }
}
