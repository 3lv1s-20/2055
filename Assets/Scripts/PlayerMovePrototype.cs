using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovePrototype : MonoBehaviour
{

    public int playerSpeed = 10;
    private bool facingRight = false;
    public int playerJumpPower = 1250;
    private float moveX;

    private dialogue dialogueScript;
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D coll;

    [SerializeField] private LayerMask canJumpOn;

    private enum MovementState { idle, running, jetpack }

    [SerializeField] private AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        dialogueScript = FindObjectOfType<dialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogueScript.IsDialogueActive())
        {
            playerMove();
            playerRaycast();
        }
    }

    void playerMove()
    {
        //Controls
        moveX = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && playerOnFloorCheck())
        {
            Jump();
            jumpSound.Play();
        }
        //animations
        //Player direction
        if (moveX < 0.0f && facingRight == false)
        {
            flipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            flipPlayer();
        }
        //physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        animationChange();
    }

    void Jump()
    {
        //jumping code
        rb.AddForce(Vector2.up * playerJumpPower);

    }

    void flipPlayer()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            //  isGrounded = true;
        }
    }

    void playerRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit.distance < 1.3f && hit.collider.tag == "ground")
        {
            //Debug.Log("Touched ground");
        }
    }

    void animationChange()
    {

        MovementState state;

        if (moveX > 0f)
        {
            state = MovementState.running;
        }
        else if (moveX < 0f)
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;

        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.idle;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.idle;
        }

        if (Input.GetKey(KeyCode.Q))
        {

            state = MovementState.jetpack;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool playerOnFloorCheck()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, canJumpOn);
    }
}