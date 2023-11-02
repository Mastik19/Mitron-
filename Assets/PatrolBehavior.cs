using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehavior : StateMachineBehaviour
{

    Transform player;
    NavMeshAgent agent;
    Transform wayPointsObject;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        wayPointsObject = animator.gameObject.transform.parent;

       

        agent = animator.gameObject.GetComponent<NavMeshAgent>();

        //if (animator.gameObject.name =="Zombie0")
        //{
        //    agent.SetDestination(wayPointsObject.transform.GetChild(0).GetChild(0).position);

        //}
        //else if(animator.gameObject.name == "Zombie1")
        //{
        //    agent.SetDestination(wayPointsObject.transform.GetChild(1).GetChild(0).position);
        //}
        //else if(animator.gameObject.name == "Zombie2")
        //{
        //    agent.SetDestination(wayPointsObject.transform.GetChild(2).GetChild(0).position);
        //}


        switch (animator.gameObject.name)
        {
            case "newZombie":
                agent.SetDestination(wayPointsObject.GetChild(0).GetChild(0).position);
                break;
            case "newZombie1":
                agent.SetDestination(wayPointsObject.GetChild(1).GetChild(0).position);
                break;
            case "newZombie2":
                agent.SetDestination(wayPointsObject.GetChild(2).GetChild(0).position);
                break;
            case "newZombie3":
                agent.SetDestination(wayPointsObject.GetChild(3).GetChild(0).position);
                break;
            case "newZombie4":
                agent.SetDestination(wayPointsObject.GetChild(4).GetChild(0).position);
                break;
            case "newZombie5":
                agent.SetDestination(wayPointsObject.GetChild(5).GetChild(0).position);
                break;
            case "newZombie6":
                agent.SetDestination(wayPointsObject.GetChild(6).GetChild(0).position);
                break;
            case "newZombie7":
                agent.SetDestination(wayPointsObject.GetChild(7).GetChild(0).position);
                break;
            case "newZombie8":
                agent.SetDestination(wayPointsObject.GetChild(8).GetChild(0).position);
                break;
            case "newZombie9":
                agent.SetDestination(wayPointsObject.GetChild(9).GetChild(0).position);
                break;




        }




    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            switch (animator.gameObject.name)
            {
                case "newZombie":
                    agent.SetDestination(wayPointsObject.GetChild(0).GetChild(Random.Range(0, 3)).position);
                    break;
                case "newZombie1":
                    agent.SetDestination(wayPointsObject.GetChild(1).GetChild(Random.Range(0, 2)).position);
                    break;
                case "newZombie2":
                    agent.SetDestination(wayPointsObject.GetChild(2).GetChild(Random.Range(0, 2)).position);
                    break;
                case "newZombie3":
                    agent.SetDestination(wayPointsObject.GetChild(3).GetChild(Random.Range(0, 2)).position);
                    break;
                case "newZombie4":
                    agent.SetDestination(wayPointsObject.GetChild(4).GetChild(Random.Range(0, 2)).position);
                    break;
                case "newZombie5":
                    agent.SetDestination(wayPointsObject.GetChild(5).GetChild(Random.Range(0, 3)).position);
                    break;
                case "newZombie6":
                    agent.SetDestination(wayPointsObject.GetChild(6).GetChild(Random.Range(0, 2)).position);
                    break;
                case "newZombie7":
                    agent.SetDestination(wayPointsObject.GetChild(7).GetChild(Random.Range(0, 2)).position);
                    break;
                case "newZombie8":
                    agent.SetDestination(wayPointsObject.GetChild(8).GetChild(Random.Range(0, 2)).position);
                    break;
                case "newZombie9":
                    agent.SetDestination(wayPointsObject.GetChild(9).GetChild(Random.Range(0, 3)).position);
                    break;




            }
        }

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < 10)
        {
            animator.SetBool("isChasing", true);
        }

    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

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

