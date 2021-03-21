using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialMessageController : MonoBehaviour 
{
    public GameObject message;
    public GameObject backGround;
    private bool activate;
    private float countTimeToDie;
    public int timeToDie;
    public GameObject nextTutorial;

	void Update () 
    {
        if(activate)
        {
            if(Time.time >= countTimeToDie)
            {
                backGround.SetActive(false);
                if(nextTutorial != null)
                {
                    nextTutorial.SetActive(true);
                }
                Destroy(message);
                Destroy(gameObject);
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            message.SetActive(true);
            backGround.SetActive(true);
            activate = true;
            countTimeToDie = Time.time + timeToDie;
        }
    }
}
