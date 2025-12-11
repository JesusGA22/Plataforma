using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class luzAutomatica : MonoBehaviour
{
    [SerializeField] string targetTag = "Player";
    [SerializeField] Light2D luz;
    [SerializeField] string encendido = "Activate";
    [SerializeField] int Tiempo = 10;

    void Start()
    {
        //poner los mensaje de error por si algo no esta definido
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag)) StartCoroutine(TurnOnOffLight());
    }

    IEnumerator TurnOnOffLight()
    {
        luz.enabled = true;
        yield return new WaitForSeconds(Tiempo);
        luz.enabled = false;

    }
}
