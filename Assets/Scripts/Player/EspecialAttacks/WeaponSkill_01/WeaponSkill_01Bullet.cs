using UnityEngine;
using System.Collections;

public class WeaponSkill_01Bullet : MonoBehaviour 
{
	private int velocity;
	private GameObject playerDamage;
    public GameObject hitParticle;

	void Awake()
	{
		playerDamage = GameObject.FindGameObjectWithTag ("Player");
		velocity = 10;
	}

	void Update () 
	{
		transform.Translate (Vector3.forward * velocity * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
        if (other.tag.Equals("Enemy") || other.tag.Equals("Inimigo"))
		{
            other.GetComponent<EnemyController>().getHit(playerDamage.gameObject.GetComponent<PlayerController>().basicStats.getDamage());
            Instantiate(hitParticle, transform.position, transform.rotation);
			Destroy(this.gameObject);
		}

        if(other.tag.Equals("Hide"))
        {
            Instantiate(hitParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
	}
}
