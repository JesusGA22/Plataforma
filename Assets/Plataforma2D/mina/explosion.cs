using System.Collections;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public string animationTriggerName = "Activada";

    [SerializeField]Animator animator;

    [SerializeField]bool disableOnTrigger=false;
    [SerializeField] float waitTime = 1f; //TODO calcular segun animacion

    private void Start()
    {
        if (animator == null) animator = GetComponentInChildren<Animator>();
        //if()
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           StartCoroutine(TriggerAndDisable());
        }
    }

    private IEnumerator TriggerAndDisable()
    {
        animator.SetTrigger(animationTriggerName);
        if (disableOnTrigger){
            yield return new WaitForSecondsRealtime(waitTime);
            gameObject.SetActive(false);
        }
    }
}
