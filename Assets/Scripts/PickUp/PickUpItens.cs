using UnityEngine;
using System.Collections;

public class PickUpItens : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)// Se nao funcionar o Trigger, aumente a area de detecçao do trigger
	{
		if(other.tag.Equals("Player"))
		{
			//Colocar o itens no inventoriro.
			print ("Item Coletado");
			Destroy(this.gameObject);
		}
	}
}
