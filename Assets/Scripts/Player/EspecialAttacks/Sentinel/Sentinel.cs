using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sentinel : MonoBehaviour 
{
    private NavMeshAgent agent;
    private Transform player;
    public GameObject bullet;
    public GameObject target;
    private float countDownAttacking;
    public Transform aim;

	void Start () 
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void Update () 
    {
        if (target != null)
        {
            LookAtEnemy();
            Attacking();
        }
        else
        {
            getMoviment();
        }
	}

    void Attacking()
    {
        agent.ResetPath();
        if(Time.time >= countDownAttacking)
        {
            countDownAttacking = Time.time + 1;

            Instantiate(bullet, aim.transform.position , aim.transform.rotation);
        }
       
    }

    public void LookAtEnemy()
    {
        Quaternion newRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        newRotation.x = 0;
        newRotation.z = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 10.0f * Time.deltaTime);
    }

    void getMoviment()
    {
        agent.SetDestination(player.position);
    }
}
