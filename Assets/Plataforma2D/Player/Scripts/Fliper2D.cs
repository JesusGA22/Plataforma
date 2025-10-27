using System;
using UnityEngine;

public class Fliper2D : MonoBehaviour
{
    [SerializeField]  bool isFacingRightByDefault = true;

    private bool facingRight;
    Rigidbody2D rb;
    SpriteRenderer sprite;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        sprite= rb.GetComponentInChildren<SpriteRenderer>();
        facingRight = isFacingRightByDefault;

    }

    // Update is called once per frame
    void Update()
    {
        Flip2D();
    }
    private void Flip2D()
    {
        //gestiona el Flip

        //si nos movemos a la derecha
        if (rb.linearVelocityX > 0.1f)
        {
            sprite.flipX = !isFacingRightByDefault;
            updateFacing();

            //EQUIVALENTE A:
            //if(isFacingRightByDefault) sprite.flipX = false;
            //else sprite.flipX = true;
        }
        if (rb.linearVelocityX < -0.1f)
        {
            sprite.flipX = isFacingRightByDefault;
            updateFacing();

            //EQUIVALENTE A:
            //if(isFacingRightByDefault) sprite.flipX = true;
            //else sprite.flipX = false;
        }
    }
    public void updateFacing()
    {
        facingRight = Math.Abs((isFacingRightByDefault ? 1 : 0) - (sprite.flipX ? 1 : 0)) == 1;
    }
    public bool isFacingRight()
    {
        return facingRight;
    }

}
