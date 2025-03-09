using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerHP : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public int health = 100;

    public Image healthBar;

    // Start is called before the first frame update

    [SerializeField] private AudioSource deathSound;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("boss"))
        {
            Die();
        }
        else if (collision.gameObject.CompareTag("trap") || collision.gameObject.CompareTag("enemy"))
        {
            Die();
        }
    }

    private void Die()
    {
        deathSound.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TakeDamage(int damage)
    {
        if (health <= 0)
        {
            Die();
        }
    }


}