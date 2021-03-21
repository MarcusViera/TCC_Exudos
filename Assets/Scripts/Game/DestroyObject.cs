using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour 
{
	private float count;
	public int timeToDie;
	void Start () 
	{
		count = Time.time + timeToDie;
	}
	
	void Update () 
	{
		if(Time.time >= count)
		{
			Destroy(gameObject);
		}
	}
}
