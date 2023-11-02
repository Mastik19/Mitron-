using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBeahviour : StateMachineBehaviour
{
    public Transform player;
    public  bool isAttacking;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        FindObjectOfType<AudioManager>().PlaySound("ZombieAttack");
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

   // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > 5 )
        {
            animator.SetBool("isAttacking", false);
            isAttacking = false;
            FindObjectOfType<CanvasManager>().isZombieAttack = false;

        }
        else
        {
            
            isAttacking = true;
            FindObjectOfType<CanvasManager>().TakeDamage();
            FindObjectOfType<CanvasManager>().isZombieAttack = true;
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FindObjectOfType<AudioManager>().StopSound("ZombieAttack");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}