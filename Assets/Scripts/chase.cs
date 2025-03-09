using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    public GameObject player;

    public float speed;
    public float distanceBetween;
    public int damageAmount = 40;

    private float dirX = 0f;
    private float distance;

    private enum animations {idle, walk, attack, fly}

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Mathf.Sign(player.transform.position.x - transform.position.x);
        
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;       

        if(distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }

        updateAnimationState();
    }

    private void updateAnimationState()
    {
        animations state;

        if (dirX > 0f)
        {
            state = animations.walk;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = animations.walk;
            sprite.flipX = true;
        }
        else
        {
            state = animations.idle;
        }

        if (distance < 12f)
        {
            DealDamage();
            state = animations.attack;
           
        }
        else if (rb.velocity.y > .1f)
        {
            state = animations.fly;
        }

       anim.SetInteger("state", (int)state);
       
    }

    private void DealDamage()
    {
        playerHP playerHealth = player.GetComponent<playerHP>();

            playerHealth.TakeDamage(damageAmount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "trap")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }
}
