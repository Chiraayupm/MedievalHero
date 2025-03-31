using System;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float speed = 9;
    public int direction = 1;
    public Rigidbody2D rb;
    public Animator anim;

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal < 0 && direction == 1 || horizontal > 0 && direction == -1)
        {
            direction *= -1;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }


        anim.SetFloat("horizontal", Math.Abs(horizontal));
        anim.SetFloat("vertical", Math.Abs(vertical));

        rb.linearVelocity = new Vector2(horizontal, vertical) * speed;

    }
}
