using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targentting : MonoBehaviour 
{

    public List<EnemyController> targets;

	void Start () 
	{
        targets = new List<EnemyController>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag.Equals("Enemy"))
		{
            EnemyController enemy = other.GetComponent<EnemyController>(); 
			targets.Add(enemy);
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.tag.Equals("Enemy"))
		{
            EnemyController enemy = other.GetComponent<EnemyController>(); 
			targets.Remove(enemy);
		}
	}
}
