using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public int damage = 50;
    public float maxDistance = 35f;

    private Rigidbody2D rb;
    private Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceTraveled = Vector2.Distance(startPosition, transform.position);

        if (distanceTraveled >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemy enemy = collision.GetComponent<enemy>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);
        }
        Destroy(gameObject);
    }
}
