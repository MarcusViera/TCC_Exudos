using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ForceField : MonoBehaviour 
{
    public int countEnemys;
    public List<EnemyController> targets;
    public bool activateEffect;
    private GameObject forceFieldSound;

    private float count;
    public int timeToDie;

    void Start()
    {
        targets = new List<EnemyController>();
        forceFieldSound = GameObject.FindGameObjectWithTag("ForceFieldSound");
        forceFieldSound.GetComponent<AudioSource>().Play();
        count = Time.time + timeToDie;
    }

    void Update()
    {
        if (Time.time >= count)
        {
            forceFieldSound.GetComponent<AudioSource>().Stop();
            Destroy(gameObject);
        }

        if(activateEffect)
        {
            if (targets.Count != 0)
            {
                foreach (EnemyController target in targets)
                {
                    if(target != null)
                    {
                        target.agent.ResetPath();
                        target.activeMove = false;
                        target.anim.SetFloat("run", 0);
                        target.anim.SetFloat("attack", 0);
                    }
                }
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            if(countEnemys < 5)
            {
                other.gameObject.tag = "Inimigo";
                activateEffect = true;
                EnemyController enemy = other.GetComponent<EnemyController>();
                targets.Add(enemy);
                countEnemys += 1;
            }
        }
    }
}
