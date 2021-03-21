using UnityEngine;
using System.Collections;

public class BulletEnemy : MonoBehaviour 
{
	private int velocity;
	private GameObject enemyDamage;
    public GameObject hitParticle;

	void Awake()
	{
		enemyDamage = GameObject.FindGameObjectWithTag ("Enemy");
		velocity = 10;
	}

	void Update () 
	{
		transform.Translate (Vector3.forward * velocity * Time.deltaTime);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag.Equals("Player"))
		{
			if(enemyDamage != null)
			{
                other.GetComponent<PlayerController>().getHit(enemyDamage.gameObject.GetComponent<EnemyController>().basicStats.getDamage());
                Instantiate(hitParticle, transform.position, transform.rotation);
				Destroy(this.gameObject);
			}
		}

        if (other.tag.Equals("Hide"))
        {
            Instantiate(hitParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
	}
}
