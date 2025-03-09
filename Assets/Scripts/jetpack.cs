using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jetpack : MonoBehaviour
{
    public int boost = 1000;
    private float moveX;

    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D coll;

    [SerializeField] private AudioSource jetpackSound;

    private enum MovementState { idle, running, jetpack }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       jetpackBoost();
    }

    void jetpackBoost()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Q))
        {
            anim.SetInteger("state", 2);
            fly();
        }
    }
    
    void fly()
    {
       // MovementState state;
       // state = MovementState.jetpack;
        rb.AddForce(Vector2.up * 175);
        //anim.SetInteger("state", (int)state);
    }


}
