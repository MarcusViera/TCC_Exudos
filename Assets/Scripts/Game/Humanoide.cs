using UnityEngine;
using System.Collections;

public abstract class Humanoide : MonoBehaviour 
{
	public BasicStats basicStats;
	
	/// Variaveis para a movimentaçao
    [HideInInspector]
	public NavMeshAgent agent;   
	
	/// Variaveis para o combate
	public float currentHealth;
	public float currentEnergy;
    public float currentShield;
	public float attackRange;
	public GameObject weaponSkill_01Bullet;
	public Transform aim;

	/// Variaveis para o Level UP
	public int level;

	/// Metodos
	public void getHit(float damage)//Método para tira a vida do jogador 
	{
        if(currentShield > 0)
        {
            currentShield -= damage;
        }
        else
        {
            currentHealth -=  damage;
        }
		
		if(currentHealth <= 0)
		{
			currentHealth = 0;
		}

        if (currentShield <= 0)
        {
            currentShield = 0;
        }
	}


    public bool isDead()//Método que checa se o jogador esta vivo
	{
		if(currentHealth <= 0)
			return true;
		else
			return false;
	}
	
}


[System.Serializable]
public class BasicStats
{
	//Atributos 
	public float dexterity;
	public float vitality;
	public float energy;
	public float protection;
	
	//Equipamentos
	public int armorEnergy ;
	public int armorVitality ;
	public int armorDexterity ;
	public int armorProtection ;

	public float getDamage()
	{
		float damage = (dexterity * GameDesign.DEXTERITY_MULTIPLIER) + geEquipmentDamage();
		return  damage;
	}
	private int geEquipmentDamage()
	{
        return armorDexterity;
	}


	public float getMaxHealth()
	{
        float health = (vitality * GameDesign.VITALITY_MULTIPLIER) + geEquipmentHealth();
		return  health;
	}
	private int geEquipmentHealth()
	{
        return armorVitality;
	}


    public float getRegenerationEnergy()
	{
        float energyRegeneration = (energy * GameDesign.ENERGY_MULTIPLIER) + getEquipmentEnergy();
		return  energyRegeneration;
	}
	private int getEquipmentEnergy()
	{
        return armorEnergy;
	}
	
	public float getMaxShield()
	{
        protection += getEquipmentShield();
        protection *= 0.01f;
        float maxShield = getMaxHealth() * protection;
		return maxShield ;
	}
	private int getEquipmentShield()
	{
        return armorProtection;
	}
}
