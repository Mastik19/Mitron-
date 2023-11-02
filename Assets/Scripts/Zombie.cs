using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Zombie : MonoBehaviour
{
    public int enemyHp;
     Animator anim;
    public  bool isDead;
    void Start()
    {
        anim = GetComponent<Animator>();
        enemyHp = 100;
        isDead = false;
    }

    public void TakeDamage(int amount)
    {
        enemyHp -= amount;
        if(enemyHp > 0 )
        {
            anim.SetTrigger("damage");
          
        }
        

        else
        {
            isDead = true;
            transform.GetComponent<CapsuleCollider>().enabled = false;
            //transform.GetComponent<NavMeshAgent>().enabled = false;
            anim.SetTrigger("death");
            
            Destroy(gameObject, 4);
        }

    }
}
