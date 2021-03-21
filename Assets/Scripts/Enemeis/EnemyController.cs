using UnityEngine;
using System.Collections;

public class EnemyController : Humanoide 
{
	public Transform playerPosition;
    
    //Variaveis para o Ataque Normal
    private float countDownNormalAttack;

	//Varivaies para a Animaçao
	public Animator anim;  

	/// Variaveis para a movimentaçao.
	private NavMeshPath path;
	private Vector3 target;
	public bool activeMove;
	public AudioSource screamSound;
	private bool sound;

	/// Variaveis para o Level Up
	public float expGive;

	//Variavies para a morte
	private float countTimeDeath;
	public float timeDeath;
	private bool activeDeath;

    //Varivaies para o Ataque arma especial 02 
    private int countWeaponSkills02;
    public bool activatedSentinelCrystalBlue;
    public bool activatedWeaponSkill02;
	
    void Awake()
    {
        target = transform.position;
        agent = GetComponent<NavMeshAgent>();
        currentHealth = basicStats.getMaxHealth();
        activeDeath = false;
        sound = false;
        agent.speed = GameDesign.ENEMY_SPEED;
        countWeaponSkills02 = 1;
        activatedSentinelCrystalBlue = false;
        activatedWeaponSkill02 = false;
    }

	void Start ()
	{
	}

	void Update () 
	{
		if(!isDead())
		{
			if(activeMove == false &&  !IsInRange(attackRange))
			{
				getIdle();
			}
			if (activeMove == true && !IsInRange(attackRange))
			{
				LookAtEnemy();
				getMoviment();
			}
			if(IsInRange(attackRange))
			{
				LookAtEnemy();
				NormalAttack();
			}
		}
		else
		{
			DieMethod();
		}
	}
	
	///Metodos que controlao a movimentaçao
	void getMoviment()
	{
		ScreamSound ();
		anim.SetFloat ("run", 0.5f);
		anim.SetFloat ("attack", 0);
		target = playerPosition.position;
		agent.SetDestination (target);
	}
	public bool IsInRange(float range)
	{
		return Vector3.Distance(this.transform.position, playerPosition.position) < range;
	}
	public void ScreamSound()
	{
		if(!sound)
		{
			sound = true;
			screamSound.Play();
		}
	}

	/// Metodo que controla a animaçao do Idle
	public void getIdle()
	{
		anim.SetFloat ("run", 0);
		anim.SetFloat ("attack", 0);
	}
	
	/// Metdos para o combate.
	public void NormalAttack()
	{
        if (Time.time >= countDownNormalAttack)
        {
            anim.SetFloat("run", 0);
            anim.SetFloat("attack", 0.5f);
            agent.ResetPath();
            countDownNormalAttack = GameDesign.ENEMY_ATTACK_SPEED + Time.time;
        }
	}

	public void LookAtEnemy()
	{
		Quaternion newRotation = Quaternion.LookRotation(playerPosition.transform.position - transform.position);    
		newRotation.x = 0;                                                                                   
		newRotation.z = 0;
		transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 10.0f*Time.deltaTime);
	}
	
	/// Metodos que controlao a morte do jogador	
	void DieMethod()
	{
        agent.ResetPath();
		if(!activeDeath)
		{
			activeDeath = true;
			playerPosition.GetComponent<PlayerController>().exp += expGive;
			Destroy(this.gameObject.GetComponent<CapsuleCollider>());
			countTimeDeath = Time.time + timeDeath;
		}

		anim.SetFloat ("run", 0);
		anim.SetFloat ("attack", 0);
		anim.SetFloat ("death", 1);

		if(Time.time >= countTimeDeath)
		{
			Destroy (this.gameObject);
		}
	}

    //Método da Sentinela Azul
    public IEnumerator SentinelCrystalBlueReducedSpeed()
    {
        agent.speed *= GameDesign.SENTINEL_CRYSTAL_BLUE_VELOCITY_PERCENTAL;

        yield return new WaitForSeconds(GameDesign.SENTINEL_CRYSTAL_BLUE_VELOCITY_TIME);

        agent.speed = GameDesign.ENEMY_SPEED;
        activatedSentinelCrystalBlue = false;
    }

    //Método da Arma 02 
    public IEnumerator WeaponSkills02_DamagePerSecond()
    {
        while(countWeaponSkills02 < 3)
        {
            currentHealth -= (playerPosition.GetComponent<PlayerController>().basicStats.getDamage() * GameDesign.WEAPON_SKILL_02_PERCENTAL_5);
            countWeaponSkills02++;
            yield return new WaitForSeconds(GameDesign.WEAPON_SKILL_02_PERCENTAL_RELOAD);
        }

        activatedWeaponSkill02 = false;
    }

    //Método de Evolução do Inimigo
    public void EnemyUpgrade()
    {
        basicStats.dexterity += basicStats.dexterity * GameDesign.ENEMY_PERCENTAL_EVOLUTION;
        basicStats.vitality += basicStats.vitality * GameDesign.ENEMY_PERCENTAL_EVOLUTION;
        basicStats.energy += basicStats.protection * GameDesign.ENEMY_PERCENTAL_EVOLUTION;
        basicStats.protection += basicStats.protection * GameDesign.ENEMY_PERCENTAL_EVOLUTION;

        expGive += expGive * GameDesign.ENEMY_PERCENTAL_EVOLUTION_EXP;

        level += 1;
    }

}
