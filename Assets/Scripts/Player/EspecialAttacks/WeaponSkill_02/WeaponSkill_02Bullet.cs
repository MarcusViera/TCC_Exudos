using UnityEngine;
using System.Collections;

public class WeaponSkill_02Bullet : MonoBehaviour 
{
    private int velocity;
    private GameObject playerDamage;
    public GameObject hitParticle;

    void Awake()
    {
        playerDamage = GameObject.FindGameObjectWithTag("Player");
        velocity = 10;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy") || other.tag.Equals("Inimigo"))
        {
            if (!other.GetComponent<EnemyController>().activatedWeaponSkill02)
            {
                StartCoroutine(other.GetComponent<EnemyController>().WeaponSkills02_DamagePerSecond());
                other.GetComponent<EnemyController>().activatedWeaponSkill02 = true;
            }

            Instantiate(hitParticle, transform.position, transform.rotation);
            other.GetComponent<EnemyController>().getHit(playerDamage.gameObject.GetComponent<PlayerController>().basicStats.getDamage() * GameDesign.WEAPON_SKILL_02_PERCENTAL_90);
            Destroy(this.gameObject);
        }

        if (other.tag.Equals("Hide"))
        {
            Instantiate(hitParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
