using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ForceFieldCrystalRed : MonoBehaviour 
{
    private GameObject playerReference;
    private float countDownHealthRegeneration;
    private float countTimeToDie;
    public int timeToDie;
    public int countEnemys;
    public List<EnemyController> targets;

    private GameObject forceFieldSound;

    void Start()
    {
        playerReference = GameObject.FindGameObjectWithTag("Player");
        forceFieldSound = GameObject.FindGameObjectWithTag("ForceFieldSound");
        forceFieldSound.GetComponent<AudioSource>().Play();
        playerReference.GetComponent<PlayerController>().activatedPercentalCrystalRed = true;
        timeToDie = 10;
        countTimeToDie = Time.time + timeToDie;
        targets = new List<EnemyController>();
    }

    void Update()
    {
        PlayerEffects();
    }

    private void PlayerEffects()
    {
        if (Time.time >= countTimeToDie)
        {
            playerReference.GetComponent<PlayerController>().activatedPercentalCrystalRed = false;
            forceFieldSound.GetComponent<AudioSource>().Stop();
            Destroy(gameObject);
        }

        if (targets.Count != 0) 
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
        if (Time.time >= countDownHealthRegeneration)//Recuperação de  5 % de vida a cada 1 segundo
        {
            playerReference.GetComponent<PlayerController>().currentHealth += (playerReference.GetComponent<PlayerController>().currentHealth *GameDesign.FORCE_FIELD_CRYSTAL_RED_PERCENTAL_HEALTH);
            countDownHealthRegeneration = Time.time + GameDesign.FORCE_FIELD_CRYSTAL_RED_RELOAD_HEALTH;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            if (countEnemys < 4)
            {
                other.gameObject.tag = "Inimigo";
                EnemyController enemy = other.GetComponent<EnemyController>();
                targets.Add(enemy);
                countEnemys += 1;
            }
        }
    }
}
