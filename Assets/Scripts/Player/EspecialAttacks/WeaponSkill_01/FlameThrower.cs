using UnityEngine;
using System.Collections;

public class FlameThrower : MonoBehaviour 
{
	public PlayerController playerReference;
	
	void OnTriggerEnter(Collider other)
	{
        if (other.tag.Equals("Enemy") || other.tag.Equals("Inimigo"))
		{
            other.GetComponent<EnemyController>().getHit(playerReference.basicStats.getDamage() * GameDesign.FLAMETHROWER_PERCENTAL);
		}
	}

    void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Enemy") || other.tag.Equals("Inimigo"))
        {
            other.GetComponent<EnemyController>().getHit(playerReference.basicStats.getDamage() * GameDesign.FLAMETHROWER_PERCENTAL);
        }
    }
}
