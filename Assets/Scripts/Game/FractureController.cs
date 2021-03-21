using UnityEngine;
using System.Collections;

public class FractureController : MonoBehaviour 
{
	public FracturedObject teste; 
	public float explodeForce;
	public Transform explodePoint;
	public AudioSource crystalSound;

    
	void OnTriggerEnter(Collider other)
	{
		if(other.tag.Equals("Bullet"))
		{
			crystalSound.Play();
			teste.Explode(explodePoint.position, explodeForce);
			Destroy(other.gameObject);
            Destroy(gameObject);
		}
	}
}
