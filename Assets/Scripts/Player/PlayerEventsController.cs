using UnityEngine;
using System.Collections;

public class PlayerEventsController : MonoBehaviour 
{
	public PlayerController playerReference;
	public AudioSource stepSound;

	//Ataque Principal
	public void InstantiateBullet()
	{
		playerReference.weaponSkill_01Sound.Play ();

        if(playerReference.weaponSkillTypeOfBullet == 1)
            Instantiate(playerReference.weaponSkill_01Bullet, playerReference.aim.transform.position, playerReference.aim.transform.rotation);
        else
            Instantiate(playerReference.weaponSkillBullet02, playerReference.aim.transform.position, playerReference.aim.transform.rotation);
	}
	public void EndAttack()
	{
		playerReference.activeMove = true;
		playerReference.anim.SetFloat ("teste", 0);
	}

	//Eventos para a animaçao de Correr
	public void Step01()
	{
		stepSound.Play ();
	}
	public void Step02()
	{
		stepSound.Play ();
	}
}
