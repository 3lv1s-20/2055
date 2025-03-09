using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_Run : StateMachineBehaviour
{

    public float speed = 2.5f;
    //public float attackRange = 3f;

    Transform player;
    Rigidbody2D rb;
   // boss boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Boss Run State Entered");

        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
       /* boss = animator.GetComponent<boss>();

        boss.player = player;

        if (player == null)
            Debug.LogError("Player not found!");
        if (rb == null)
            Debug.LogError("Rigidbody2D not found!");
        if (boss == null)
            Debug.LogError("Boss script not found!");*/

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Debug.Log("Boss Run State Updated");

        //boss.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos =  Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);

        Debug.Log($"Target: {target}, Current: {rb.position}, New: {newPos}");

        rb.MovePosition(newPos);

        /*if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("attack");
        }*/
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // animator.ResetTrigger("attack");
    }


}
