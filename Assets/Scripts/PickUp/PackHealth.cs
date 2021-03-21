using UnityEngine;
using System.Collections;

public class PackHealth : MonoBehaviour 
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().currentHealth += GameDesign.PACK_REGENATION;
            Destroy(this.gameObject);
        }
    }
}
