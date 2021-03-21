using UnityEngine;
using System.Collections;

public class FoloowPlayer : MonoBehaviour 
{
	public Transform playerTransform;
    public float xPosition;
    public float zPosition;

	void Update () 
	{
        transform.position = new Vector3(playerTransform.position.x + xPosition, this.transform.position.y, playerTransform.position.z + zPosition);
	}
}
