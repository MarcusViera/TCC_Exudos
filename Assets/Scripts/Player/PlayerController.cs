using UnityEngine;
using System.Collections;

public class PlayerController : Humanoide 
{ 
	public GameObject oponente;

	//Varivaies para a Animaçao
	public Animator anim;                                                                
	
	/// Variavies para a movimentaçao
	[HideInInspector]
	public Vector3 position; 
	private NavMeshPath path;
	private int layerMask = 1 << 8;
	public bool activeMove = true;

	/// Variavies para o ataque normal e o Combate
    [HideInInspector]
	public Vector3 positionAttack; 
	//private bool activeLook;

    //Variavies para o Ataque de arma 01 e 02
    public AudioSource weaponSkill_01Sound;
    public int weaponSkillTypeOfBullet;
    public GameObject weaponSkillBullet02;

	/// Variaveis para o Explosão de Energia
 	[HideInInspector]
	public Vector3 cursorPosition;                                                                                          
	public GameObject bulletEnergyExplosion;                                            
	private float countDownEnergyExplosion;
	public AudioSource energyExplosionSound;
	
	/// Variaveis para o Ataque Lança Chamas
	public GameObject flameThrowerBullet;
	public GameObject flameThrowerParticle;
	private bool flameThrowerActiveLook;
	public AudioSource flameThrowerSound;

    ///Variaveis para o Ataque especial ForceField
    public GameObject[] forceFieldBullets;
    //[HideInInspector]
    public int forceFieldTypeOfBullet;
    private float countDownAttackForceField;
    //Cristal Vermelho
    [HideInInspector]
    public bool activatedPercentalCrystalRed;

    //Varivaeis para o Ataque especial Sentinela
    public GameObject[] SentinelBullets;
    //[HideInInspector]
    public int sentinelTypeOfBullet;
    private float countDownAttackSentinel;
    public Transform sentinelSpaw;

	/// Variaveis para a regeneraçao de vida, defesa e energia
	private float countDownRegeHealth;
    private float countDownRegenerationEnergy;
    private float countDownRegenerationShield;

	/// Variaveis para o metodo de morte 
	public GameObject deathPane;
	private float countTimeDeath;
	public float timeofDeath;
	private bool activeDeath;
	
	/// Variaveis para o Level Up
	public float exp;
	
	/// Variaveis para o Level Up
	public int numberOfCristalBlue, numberOfCristalGreen, numberOfCristalYelow, numberOfCristalRed;

    void Awake()
    {
        //Movimento
        position = transform.position;
        agent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        agent.speed = GameDesign.PLAYER_SPEED;

        //Combate
        //activeLook = false;
        flameThrowerActiveLook = false;
        currentHealth = basicStats.getMaxHealth();
        currentShield = basicStats.getMaxShield();
        currentEnergy = GameDesign.MAX_ENERGY;

        //Tipo de arma
        weaponSkillTypeOfBullet = 1;

        //Campo de força
        forceFieldTypeOfBullet = 1;
        //Campo de Forca cristal vermelho
        activatedPercentalCrystalRed = false;

        //Sentinela
        sentinelTypeOfBullet = 1;

        //Morte
        activeDeath = false;
    }

	void Start () 
	{	
	}

	void Update ()
	{
		if(!isDead())
		{
			//Inputs para a movimentaçao
			if(oponente == null)
			{
				if(Input.GetMouseButton(0) && activeMove)
				{
					LocatePosition();
				}
				if(agent.hasPath)
				{
					anim.SetFloat("teste", 0);
					anim.SetFloat("run", 0.5f);
					LookAtPoint(position);
				}
				else
				{
					anim.SetFloat("run", 0);
				}
			}

			//Inputs para o combate
			RayCastMouseAttack();

			//Ataque longa distancia
			if(Input.GetMouseButton(0))
			{
				if(oponente != null)
				{
					activeMove = false;
				}
				if(!activeMove)
				{
					agent.ResetPath();
					NormalAttack();
				}
			}
			if(Input.GetMouseButtonUp(0))
			{
				anim.SetFloat("teste", 0);
			}

			//Ataque Normal segurando o Shift
			if(Input.GetKey(KeyCode.LeftShift))
			{
				agent.ResetPath();
				activeMove = false;
				LocateCursor();
				LookAtPoint(cursorPosition);
				if(Input.GetMouseButton(0))
				{
					NormalAttack();
				}
			}
			if(Input.GetKeyUp(KeyCode.LeftShift))
			{
				activeMove = true;
			}
			
			//Ataque Lança Chamas
			if(Input.GetMouseButton(1))
			{
                if(currentEnergy >= 8)
                {
                    currentEnergy -= GameDesign.FLAMETHROWER_COST;

				    AttackFlameThrowerActivate();
                }
                else
                {
                    AttackFlameThrowerDeactivate();
                }
			}
			if(Input.GetMouseButtonUp(1))
			{
				AttackFlameThrowerDeactivate();
			}
			if(flameThrowerActiveLook)
			{
				LocateCursor();
				LookAtPoint(cursorPosition);

                if(!flameThrowerSound.isPlaying)
                {
                    flameThrowerSound.Play();
                }
			}
			
			//Ataque especial Explosão de Energia
            //if(Input.GetKeyUp(KeyCode.A) && Time.time >= countDownEnergyExplosion)
            //{
            //    if(currentEnergy >= GameDesign.ENERGY_EXPLOSION_COST)
            //    {
            //        LocateCursor();
            //        EnergyExplosion();
            //        currentEnergy -= GameDesign.ENERGY_EXPLOSION_COST;
            //        countDownEnergyExplosion =  GameDesign.ENERGY_EXPLOSION_RELOAD + Time.time;
            //    }
            //}

            //Ataque campo de força
            if (Input.GetKeyUp(KeyCode.Q) && Time.time >= countDownAttackForceField)
            {
                LocateCursor();
                ForceField();
            }

            //Ataque Sentinela
            if (Input.GetKeyUp(KeyCode.W) && Time.time >= countDownAttackSentinel)
            {
                Sentinel();
            }

			//Regeneraçao de vida e mana
			RegenerationHealth();
			RegenerationEnergy();
            RegenerationShield();
		}
		else
		{
			Die();
		}
	}

	/// Metodos para a movimentaçao
	public void LocatePosition()
	{
        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                if (hit.collider.tag != "Player" && hit.collider.tag != "Enemy")
                {
                    position = hit.point;
                    agent.CalculatePath(position, path);
                    agent.SetPath(path);
                }
            }
        }
	}
	
	public void LookAtPoint(Vector3 position)//Faz o Jogador Olhar para certo Ponto
	{
		Quaternion newRotation = Quaternion.LookRotation(position - this.transform.position, Vector3.forward);    
		newRotation.x = 0;                                                                                   
		newRotation.z = 0;
		transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 10.0f*Time.deltaTime);
	}
	
    //Métodos para o combate
	public  void NormalAttack()//Ataque normal
	{
		anim.SetFloat("run", 0);
		anim.SetFloat ("teste", 0.5f);
		if(oponente != null && !Input.GetKey(KeyCode.LeftShift))
		{
			positionAttack = new Vector3(oponente.transform.position.x,oponente.transform.position.y, oponente.transform.position.z); 
			LookAtPoint(positionAttack);
		}
	}

	public void EnergyExplosion()//Ataque 02
	{
		energyExplosionSound.Play ();
		Instantiate (bulletEnergyExplosion, new Vector3(cursorPosition.x,cursorPosition.y , cursorPosition.z), Quaternion.identity);
	}

	public void AttackFlameThrowerActivate()//Ataque Fire Ativo
	{
		agent.ResetPath();
		flameThrowerBullet.SetActive(true);
		flameThrowerParticle.SetActive (true);
		flameThrowerActiveLook = true;
	}
	public void AttackFlameThrowerDeactivate()//Ataque Fire Desativar
	{
		flameThrowerSound.Stop ();
		flameThrowerBullet.SetActive(false);
		flameThrowerParticle.SetActive(false);
		flameThrowerActiveLook = false;
	}

    void ForceField()
    {
        //attack01Sound.Play();
        if (forceFieldTypeOfBullet == 1)
        {
            if (currentEnergy >= GameDesign.FORCE_FIELD_COST)
            {
                currentEnergy -= GameDesign.FORCE_FIELD_COST;
                countDownAttackForceField = Time.time + GameDesign.FORCE_FIELD_COST_RELOAD;
                Instantiate(forceFieldBullets[0], new Vector3(cursorPosition.x, cursorPosition.y + 2.0f, cursorPosition.z), Quaternion.identity);
            }
        }
        else if (forceFieldTypeOfBullet == 2)
        {
            if (currentEnergy >= GameDesign.FORCE_FIELD_CRYSTAL_YELLOW_COST)
            {
                currentEnergy -= GameDesign.FORCE_FIELD_CRYSTAL_YELLOW_COST;
                countDownAttackForceField = Time.time + GameDesign.FORCE_FIELD_CRYSTAL_YELLOW_RELOAD;
                Instantiate(forceFieldBullets[1], new Vector3(cursorPosition.x, cursorPosition.y + 2.0f, cursorPosition.z), Quaternion.identity);
            }          
        }
        else
        {
            if (currentEnergy >= GameDesign.FORCE_FIELD_CRYSTAL_RED_COST)
            {
                currentEnergy -= GameDesign.FORCE_FIELD_CRYSTAL_RED_COST;
                countDownAttackForceField = Time.time + GameDesign.FORCE_FIELD_CRYSTAL_RED_RELOAD;
                Instantiate(forceFieldBullets[2], new Vector3(cursorPosition.x, cursorPosition.y + 2.0f, cursorPosition.z), Quaternion.identity);
            }          
        }
    }

    void Sentinel()
    {
        //attack01Sound.Play();
        if(sentinelTypeOfBullet == 1)
        {
            if (currentEnergy >= GameDesign.SENTINEL_COST)
            {
                currentEnergy -= GameDesign.SENTINEL_COST;
                countDownAttackSentinel = Time.time + GameDesign.SENTINEL_RELOAD;
                Instantiate(SentinelBullets[0], sentinelSpaw.position, sentinelSpaw.rotation);
            }
        }
        else if (sentinelTypeOfBullet == 2)
        {
            if (currentEnergy >= GameDesign.SENTINEL_CRYSTAL_BLUE_COST)
            {

                currentEnergy -= GameDesign.SENTINEL_CRYSTAL_BLUE_COST;
                countDownAttackSentinel = Time.time + GameDesign.SENTINEL_CRYSTAL_BLUE_RELOAD;
                Instantiate(SentinelBullets[1], sentinelSpaw.position, sentinelSpaw.rotation);
            }
        }
        else
        {
            if (currentEnergy >= GameDesign.SENTINEL_CRYSTAL_GREEN_COST)
            {

                currentEnergy -= GameDesign.SENTINEL_CRYSTAL_GREEN_COST;
                countDownAttackSentinel = Time.time + GameDesign.SENTINEL_CRYSTAL_GREEN_RELOAD;
                Instantiate(SentinelBullets[2], sentinelSpaw.position, sentinelSpaw.rotation);
                Instantiate(SentinelBullets[2], new Vector3(sentinelSpaw.position.x + 10, sentinelSpaw.position.y, sentinelSpaw.position.z), sentinelSpaw.rotation);
            }
        }
    }

	public void LocateCursor()//Método que localiza o cursor do mouse 
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
		{
			cursorPosition = hit.point;
		}
	}

	public void RayCastMouseAttack()//Método para localizar o inimigo com o mouse.
	{
        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity /*, layerMask_02*/))
            {
                if (hit.collider.tag == "Enemy" || hit.collider.tag == "Inimigo")
                {
                    oponente = hit.collider.gameObject;
                    //oponente.GetComponent<AbominationController>().activeChangeColor = true;
                    activeMove = false;
                }
                else
                {
                    oponente = null;
                    activeMove = true;
                }
            }
        }
	}

    //Métodos para Regeneração de vida, mana, e defeça.
	public void RegenerationHealth()//Regeneraçao de vida
	{
		if( Time.time >= countDownRegeHealth)
		{
			if(currentHealth >= basicStats.getMaxHealth())
			{
				currentHealth = basicStats.getMaxHealth();
				countDownRegeHealth = Time.time + GameDesign.HEALTH_REGENETATION_RELOAD;
			}
			else
			{
				currentHealth += GameDesign.HEALTH_REGENERATION;
                countDownRegeHealth = Time.time + GameDesign.HEALTH_REGENETATION_RELOAD;
			}
		}
	}

	public void RegenerationShield()//Regeneraçao de Defesa
	{
		if(Time.time >=  countDownRegenerationShield)
		{
            currentShield = basicStats.getMaxShield();
            countDownRegenerationShield = Time.time + GameDesign.SHIELD_RELOAD;
		}
	}

	public void RegenerationEnergy()	//Regeneraçao de Mana
	{
		if(Time.time >=  countDownRegenerationEnergy)
		{
			if(currentEnergy >= GameDesign.MAX_ENERGY)
			{
                currentEnergy = GameDesign.MAX_ENERGY;
				countDownRegenerationEnergy = Time.time + GameDesign.ENERGY_RELOAD;
			}
			else
			{
                if(activatedPercentalCrystalRed)
                {
                    currentEnergy += basicStats.getRegenerationEnergy() * GameDesign.FORCE_FIELD_CRYSTAL_RED_PERCENTAL_ENERGY;
                    countDownRegenerationEnergy = Time.time + GameDesign.ENERGY_RELOAD;
                }
                else
                {
                    currentEnergy += basicStats.getRegenerationEnergy();
                    countDownRegenerationEnergy = Time.time + GameDesign.ENERGY_RELOAD;
                }
			}
			
		}
	}

	/// <summary>
	/// Metodo inicar a morte
	/// </summary>
	public void Die()
	{
		anim.SetFloat("run", 0);
		anim.SetFloat("teste", 0);
		anim.SetFloat("death", 1);

		if(!activeDeath)
		{
			activeDeath = true;
			countTimeDeath = Time.time + timeofDeath;
		}

		if(Time.time >= countTimeDeath)
		{
			deathPane.SetActive(true);
		}
	}
}