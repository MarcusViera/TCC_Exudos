using UnityEngine;
using System.Collections;

public class TriggerLook : MonoBehaviour 
{
	private Transform target;
    public EnemyController enemyReference;
	private bool playerDetected;
	
	void Update () 
	{
		if (playerDetected) 
		{
			CastRayCast();
		}

	}

	void CastRayCast()
	{
		Vector3 dir = target.transform.position - this.transform.parent.position;
		RaycastHit hit;
		if(Physics.Raycast(this.transform.parent.position, dir, out hit, Mathf.Infinity))
		{
            Debug.Log("Ray Cast");
			Debug.DrawRay(this.transform.parent.position, dir, Color.red);
			if(hit.collider.tag != "Player")
			{
                Debug.Log("Não Moviemente");
				enemyReference.activeMove = false;
			}
			if(hit.collider.tag == "Player")
			{
                Debug.Log("Se Moviemente");
				enemyReference.activeMove = true;
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag.Equals("Player"))
		{
            Debug.Log("Entrou");
			target = other.transform;
			playerDetected = true;
		}
	}

    //void OnTriggerExit(Collider other)
    //{
    //    if(other.tag.Equals("Player"))
    //    {
    //        Debug.Log("Entrou Exit");
    //        target = null;
    //        playerDetected = false;
    //    }
    //}
}
