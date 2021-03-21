using UnityEngine;
using System.Collections;

public class ScenarioLimits : MonoBehaviour 
{	
	void OnTriggerEnter(Collider other)
	{
        if (other.tag.Equals("Bullet") || other.tag.Equals("BulletEnemy"))
		{
            Destroy(other.gameObject);
		}
	}
}
