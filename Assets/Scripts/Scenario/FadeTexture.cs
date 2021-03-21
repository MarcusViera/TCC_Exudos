using UnityEngine;
using System.Collections;

public class FadeTexture : MonoBehaviour 
{
	float transp = 1;
	float transpRate = 0.1f;
	float transpTime;
	float rate = 0.1f;
	public bool turnTransp = false;
	Material objectMaterial;


	void Start()
	{
		transpTime = Time.time + rate;
		objectMaterial = this.GetComponent<MeshRenderer> ().material;
	}

	void Update()
	{
		if (turnTransp) 
		{
			LerpTrans ();
		} 
		else 
		{
			transp = 1;
			objectMaterial.color = new Color(1, 1, 1, transp);
		}
	}

	void LerpTrans()
	{
		if (Time.time > transpTime) 
		{
			transp -= transpRate;
			if(transp <= 0)
			{
				transp = 0;
			}
			transpTime = Time.time + rate;
			objectMaterial.color = new Color(1,1,1, transp);
		}

	}


	void OnTriggerEnter(Collider other)
	{
		if(other.tag.Equals("Hide"))
		{
			turnTransp = true;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.tag.Equals("Hide"))
		{
			turnTransp = false;
		}
	}
}
