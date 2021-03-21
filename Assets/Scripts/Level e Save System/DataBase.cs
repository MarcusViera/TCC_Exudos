using UnityEngine;
using System.Collections;

public class DataBase : MonoBehaviour 
{
	public int interval;
	int count;

	void Start () 
	{
	}
	
	void Update () 
	{
//		if(count == interval)
//		{
//			count = 0;
//		}
//		count++;
	}

	//Level
	public static void saveLevel(int level)
	{
		PlayerPrefs.SetInt("Level", level);
	}
	public static int readLevel()
	{
		return PlayerPrefs.GetInt("Level");
	}
	//Experiencia
	public static void saveExperience(int exp)
	{
		PlayerPrefs.SetInt("Experience", exp);
	}
	public static int readExperience()
	{
		return PlayerPrefs.GetInt("Experience");
	}

	public static void saveMaxHealth(int maxHealth)
	{
		PlayerPrefs.SetInt("MaxHealth", maxHealth);
	}
	public static int readMaxHealth()
	{
		return PlayerPrefs.GetInt("MaxHealth");
	}

	
//	public static void saveMobHealth(int id, int health)//Metodo que salva a vida dos inimigos
//	{
//		PlayerPrefs.SetInt("MobHealth - " + id, health);
//	}
//	public static int readMobHealth(int id)//Metodo que carrega a vida dos inimigos
//	{
//		if(PlayerPrefs.HasKey("MobHealth - " + id))
//			return PlayerPrefs.GetInt("MobHealth - " + id);
//		else
//			return -1;
//	}
}
