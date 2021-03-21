using UnityEngine;
using System.Collections;

public class Enemy01_EventsController : MonoBehaviour 
{
    public EnemyController enemyReference;
    public AudioSource stepSound;
    public AudioSource weaponSound;

    //Eventos para a Animaçao do Ataque
    public void InstantiateBullet()
    {
        weaponSound.Play();

        Instantiate(enemyReference.weaponSkill_01Bullet, enemyReference.aim.transform.position, enemyReference.aim.transform.rotation);
    }

    public void EndAttack()
    {
    }

    public void Step01()
    {
        stepSound.Play();
    }
    public void Step02()
    {
        stepSound.Play();
    }
}
