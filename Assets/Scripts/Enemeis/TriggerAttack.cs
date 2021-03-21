using UnityEngine;
using System.Collections;

public class TriggerAttack : MonoBehaviour 
{
    public EnemyController enemy;

	void OnTriggerEnter(Collider other)
	{
		if(other.tag.Equals("Player"))
		{
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag.Equals("Player"))
		{
		}
	}
}
