using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;

    public float Speed = 5f; //pelaajan juoksu nopeus
    public ParticleSystem dust;
    [SerializeField]private float jumpForce = 14f; //pelaajan hyppykorkeus

    private enum MovementState { idle, running, jumping, falling, doublejump }

    private float dirX = 0f;

    public int maxDoubleJumps = 1;
    private int doubleJumpCount = 0;
    [SerializeField] private AudioSource jumpSoundEffect;


    private void Start()
    {
        doubleJumpCount = maxDoubleJumps;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()   
    {
        dirX = Input.GetAxisRaw("Horizontal"); //Pelaajan liike
        rb.velocity = new Vector2(dirX * Speed, rb.velocity.y); 


        if (Input.GetButtonDown("Jump") && IsGrounded() == true) //testaa onko pelaaja maassa ja painaako hän hyppy nappia
        {
            createDust();
            Debug.Log("JUMP: JUMPS LEFT " + doubleJumpCount);
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButtonDown("Jump") && doubleJumpCount > 0 && IsGrounded() == false) //tuplahyppy
        {
            createDust();
            doubleJumpCount -= 1;
            Debug.Log("DOUBLEJUMP: JUMPS LEFT " + doubleJumpCount);
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (IsGrounded() == true)
        {
            doubleJumpCount = maxDoubleJumps;
        }
        
        UpdateAnimationState();
    }

    private void UpdateAnimationState() //Vaihtaa animaatiot pelaajalle
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false; //kääntää pelaajan toiseen suuntaan
        }
        else if (dirX < 0)
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
                if (doubleJumpCount == maxDoubleJumps)
                {
                    state = MovementState.jumping;
                }
                else
                {
                    state = MovementState.doublejump;
                }
            }
            else if (rb.velocity.y < -.1f)
            {
                state = MovementState.falling;
            }
        

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded() //funktio testaa onko pelaaja maassa
    {
        float extraHeightTest = 1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size - new Vector3(0.9f, 0.9f, 0.9f), 0f, Vector2.down, extraHeightTest, jumpableGround);
        return raycastHit.collider != null;

        /*old method
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 2f, jumpableGround);
        */
    }  


    private void createDust()
    {
        dust.Play();
    }
}
