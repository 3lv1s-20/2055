using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipObject : MonoBehaviour
{
    public int xMoveDirection;
    private bool facingRight = false;

    [SerializeField] private GameObject[] waypoints;
    private int currentWaypoint = 0;

    [SerializeField] private float speed = 5f;

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(waypoints[currentWaypoint].transform.position, transform.position) < .1f)
        {
            flipEnemy();
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * speed);

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
