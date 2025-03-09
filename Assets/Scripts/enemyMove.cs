using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{

    public int enemySpeed;
    public int xMoveDirection;
    private bool facingRight = false;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2(xMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2(xMoveDirection, 0) * enemySpeed;
        if (hit.distance < 0.7f)
        {
            flip();
            flipEnemy();
        }

    }
    //flip movement direction
    void flip()
    {
        if (xMoveDirection > 0)
        {
            xMoveDirection = -1;
        } else
        {
            xMoveDirection = 1;
        }
    }

    //flip facing side
    void flipEnemy()
    {
        facingRight = !facingRight;

        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
