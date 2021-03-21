using UnityEngine;
using System.Collections;

public class LevelSystem : MonoBehaviour 
{
	public PlayerController playerReference;
	
	void Update () 
	{
		LevelUp();
	}

	void LevelUp()
	{
        //if (playerReference.exp >= (playerReference.exp + 1) * 200)
        //{
        //      playerReference.exp = playerReference.exp - (int)((playerReference.level + 1) * 200);
        //      playerReference.level = playerReference.level +1;
        //      LevelEffect();
        //      EnemyUpgrade();
        //}

        if (playerReference.exp >= (Mathf.Pow(playerReference.level, 2) + 100))
        {
            playerReference.exp = playerReference.exp - (int)(Mathf.Pow(playerReference.level, 2) + 100);
            playerReference.level = playerReference.level + 1;
            LevelEffect();
            EnemyUpgrade();
        }
	}

	void LevelEffect()
	{
		GameDesign.CURRENT_POINTS += GameDesign.LEVEL_POINTS;
	}

    void EnemyUpgrade()
    {

        EnemyController[] enemys = FindObjectsOfType(typeof(EnemyController)) as EnemyController[];
        foreach (EnemyController enemy in enemys)
        {
            enemy.EnemyUpgrade();
        }
    }
}
