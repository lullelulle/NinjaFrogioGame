using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneFrogMove : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 5f;
    private float jumpForce = 14f;

    private bool move = false;
    private int direction = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(6);
        Jump();
        move = true;

        yield return new WaitForSeconds(4);
        Jump();

        yield return new WaitForSeconds(2.5f);
        move = false;

        yield return new WaitForSeconds(9);
        direction = -1;
        move = true;

        yield return new WaitForSeconds(0.5f);
        direction = 1;
        Jump();
        
    }

    void Update()
    {
        if (move == true)
        {
            rb.velocity = new Vector2(speed * direction, rb.velocity.y);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

}
