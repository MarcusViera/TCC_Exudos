using UnityEngine;
using System.Collections;
//Marcus Vinicius de Brito Vieira Filho

public class EnergyExplosion : MonoBehaviour 
{
    private GameObject playerReference;

	void Start()
	{
        playerReference = GameObject.FindGameObjectWithTag("Player");
	}

	void OnTriggerEnter(Collider other)
	{
        if (other.tag.Equals("Enemy") || other.tag.Equals("Inimigo"))
		{
            other.gameObject.GetComponent<EnemyController>().getHit(playerReference.GetComponent<PlayerController>().basicStats.getDamage() * GameDesign.ENERGY_EXPLOSION_DAMAGE_PERCENTAL);
		}
	}
}
