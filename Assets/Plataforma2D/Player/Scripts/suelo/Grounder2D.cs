using Unity.VisualScripting;
using UnityEngine;

[DisallowMultipleComponent]

public class Grounder2D : MonoBehaviour, IGrounded2D
{
    public GameObject puntoSuelo;
    public float distance = 1f;

    private bool suelo;
    public bool IsGrounded => suelo;

    public bool IsGroundedRaw => suelo;

    private bool IsGroundedInternal()
    {
        LayerMask layerMask = LayerMask.GetMask("Ground");

        RaycastHit2D hit = Physics2D.Raycast(puntoSuelo.transform.position, Vector2.down, distance, layerMask);

        // Does the ray intersect any objects excluding the player layer
        if (hit)

        {
            Debug.DrawRay(puntoSuelo.transform.position, Vector2.down * hit.distance, Color.red, 1f);
            return true;
        }
        else
        {
            Debug.DrawRay(puntoSuelo.transform.position, Vector2.down * distance, Color.white, 1f);
            return false;
        }
    }
    private void Update()
    {
        suelo=IsGroundedInternal();
    }
}
