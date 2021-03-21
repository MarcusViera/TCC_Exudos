using UnityEngine;
using System.Collections;

public class PickUpCristal : MonoBehaviour 
{
	public int typeOfCristal; 
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag.Equals("Player"))
		{
			if(typeOfCristal == 1)
			{
				other.gameObject.GetComponent<PlayerController>().numberOfCristalBlue += 5;
				Destroy(gameObject);
			}
			else if(typeOfCristal == 2)
			{
				other.gameObject.GetComponent<PlayerController>().numberOfCristalGreen += 5;
				Destroy(gameObject);
			}
			else if (typeOfCristal == 3)
			{
				other.gameObject.GetComponent<PlayerController>().numberOfCristalRed += 5;
				Destroy(gameObject);
			}
			else
			{
				other.gameObject.GetComponent<PlayerController>().numberOfCristalYelow += 5;
				Destroy(gameObject);
			}
		}
	}
}
