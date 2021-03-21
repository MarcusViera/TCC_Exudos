using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ForceFieldCristalYellow : MonoBehaviour 
{
    private GameObject playerReference;
    public int countEnemys;
    public List<EnemyController> targets;
    private float countDownDamage;
    public bool activateEffect;
    private GameObject forceFieldSound;

    private float count;
    public int timeToDie;

    void Start()
    {
        targets = new List<EnemyController>();
        playerReference = GameObject.FindGameObjectWithTag("Player");
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

        if (activateEffect)
        {
            if(targets.Count != 0)
            {
                foreach (EnemyController target in targets)//Paralisa o Movimento
                {
                    if (target.currentHealth <= 0)
                    {
                        targets.Remove(target);
                    }

                    target.agent.ResetPath();
                    target.activeMove = false;
                    target.anim.SetFloat("run", 0);
                    target.anim.SetFloat("attack", 0);
                }
            }
           
            if (Time.time >= countDownDamage) //Tira a vida do inimigo
            {
                if (targets.Count != 0)
                {
                    foreach (EnemyController target in targets)
                    {
                        target.getHit(playerReference.GetComponent<PlayerController>().basicStats.getDamage() * GameDesign.FORCE_FIELD_CRYSTAL_YELLOW_PERCENTAL);
                    }
                }              
                countDownDamage = Time.time + GameDesign.FORCE_FIELD_CRYSTAL_YELLOW_DAMAGE_RELOAD;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            if (countEnemys < 4)
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
