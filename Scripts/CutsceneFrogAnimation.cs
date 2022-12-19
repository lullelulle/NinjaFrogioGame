using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneFrogAnimation : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    private enum MovementState { idle, running, jumping, falling, doublejump }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }



    private void Update()
    {
        UpdateAnimationState();
    }

    private void UpdateAnimationState() //Vaihtaa animaatiot pelaajalle
    {
        MovementState state;
        if (rb.velocity.x > .1f)
        {
            state = MovementState.running;
            sprite.flipX = false; //kääntää pelaajan toiseen suuntaan
        }
        else if (rb.velocity.x < -.1f)
        {
            state = MovementState.running;
            sprite.flipX = true; //kääntää pelaajan toiseen suuntaan
        }
        else
        {
            state = MovementState.idle;
        }
            if (rb.velocity.y > .1f)
            {
                state = MovementState.jumping;
            }
            else if (rb.velocity.y < -.1f)
            {
                state = MovementState.falling;
            }
        

        anim.SetInteger("state", (int)state);

    }
}

