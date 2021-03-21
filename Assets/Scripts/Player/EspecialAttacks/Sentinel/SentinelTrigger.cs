using UnityEngine;
using System.Collections;

public class SentinelTrigger : MonoBehaviour 
{
    public Sentinel sentinelReference;
	
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy") || other.tag.Equals("Inimigo"))
        {
            if(sentinelReference.target == null)
            {
                sentinelReference.target = other.gameObject;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Enemy")  || other.tag.Equals("Inimigo"))
        {
            if (sentinelReference.target == null)
            {
                sentinelReference.target = other.gameObject;
            }
        }
    }

}
