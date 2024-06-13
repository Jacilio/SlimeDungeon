using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyBasic : MonoBehaviour
{
    //basic variables
    GameObject player;
    [SerializeField]
    LayerMask playerL;
    NavMeshAgent agent;
    [SerializeField]
    Animator animator;
    public PlayerLifeMana playerLife;
    public int damage;

    //attack variables
    public float atkRange;
    public bool isAttacking;
    public float atkTime, atkCD;

    private void Start()
    {
        player = GameObject.Find("PlayerROOT"); 
        playerLife = player.GetComponent<PlayerLifeMana>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        atkTime += Time.deltaTime;
        isAttacking = Physics.CheckSphere(agent.transform.position, atkRange, playerL);
        if (isAttacking && atkTime >= atkCD)
        {
            Attack();
        }
        if (!isAttacking)
        {
            Chase();
        }
    }

    void Attack()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            
            animator.SetTrigger("Attack");
            agent.SetDestination(transform.position);
            atkTime = 0;

        }
        
    }

    void Chase()
    {
       
        agent.SetDestination(player.transform.position);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerLife.DamageTaken(damage);
        }
    }*/
}
