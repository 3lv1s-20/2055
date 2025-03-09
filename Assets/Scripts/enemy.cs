using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class enemy : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    private Animator anim;
    private Rigidbody2D rb;
    public bool isBoss = false;
    public bool isSoldier = false;

    [SerializeField] private AudioSource deathSound;

    [SerializeField] floatingHealthBar healthBar;

    private void Awake()
    {
        healthBar = GetComponentInChildren<floatingHealthBar>();
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        healthBar.UpdateHealthBar(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage)
    {
        health -= damage;

        if (isBoss)
        {
            healthBar.UpdateHealthBar(health, maxHealth);
        }        

        if (health <= 0)
        {
            if (isBoss)
            {
                DieBoss();
            }
            else if (isSoldier)
            {
                DieSoldier();
            }
            else
            {
                Die();
            }
        }
    }

    void Die()
    {
        anim.SetTrigger("death");    
        transform.gameObject.tag = "Untagged";      
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        deathSound.Play();
        gameObject.GetComponent<chase>().enabled = false;
        gameObject.GetComponent<flipObject>().enabled = false;
        float delayInSeconds = 0.3f;
        Invoke("MoveEnemyDown", delayInSeconds);
      
    }

    void MoveEnemyDown()
    {
        float moveDownAmount = 1.2f;
        transform.position = new Vector2(transform.position.x, transform.position.y - moveDownAmount);
        Destroy(gameObject, 3);
    }

    void DieSoldier()
    {
        gameObject.GetComponent<chase>().enabled = false;
        gameObject.GetComponent<flipObject>().enabled = false;
        anim.SetTrigger("death");
        transform.gameObject.tag = "Untagged";
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        deathSound.Play();
        Destroy(gameObject, 0.6f);
        
    }

        void DieBoss()
    {
        anim.SetTrigger("death");
        gameObject.GetComponent<chase>().enabled = false;
        transform.gameObject.tag = "Untagged";
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        deathSound.Play();
        Destroy(gameObject, 3);

    }

}
