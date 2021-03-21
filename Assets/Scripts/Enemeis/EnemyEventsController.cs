using UnityEngine;
using System.Collections;

public class EnemyEventsController : MonoBehaviour 
{
	public PlayerController playerReference;
	public GameObject enemyReference;

	//Eventos para a Animaçao do Ataque
	public void GetHit()
	{
        playerReference.getHit(enemyReference.GetComponent<EnemyController>().basicStats.getDamage());
	}

	public void EndAttack()
	{
	}
}
