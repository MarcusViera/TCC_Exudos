using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy_HealthBar : MonoBehaviour 
{
    public PlayerController playerReference;
    public EnemyController enemyReference;

	public Image healthBar;
	public Image backGround;
    public Image backGroundHealth;

    public Text enemyName;
    public Text healthPercentage;
	
	void Update()
	{
		if(playerReference.oponente != null)
		{
            enemyReference = playerReference.gameObject.GetComponent<PlayerController>().oponente.GetComponent<EnemyController>();
			healthBar.enabled = true;
			backGround.enabled = true;
            backGroundHealth.enabled = true;
            enemyName.enabled = true;
            healthPercentage.enabled = true;
			HealthBarIsActive();
		}
		else
		{
			healthBar.enabled = false;
			backGround.enabled = false;
            backGroundHealth.enabled = false;
            enemyName.enabled = false;
            healthPercentage.enabled = false;
		}
	} 
		
	public void HealthBarIsActive()
	{
        //Nome do Inimigo
        enemyName.text = enemyReference.name;

        //Porcentagem da vida
        healthPercentage.text = HealthPercentage().ToString() + "%";

        //Barra de vida
		healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, enemyReference.currentHealth / enemyReference.basicStats.getMaxHealth(), 1.0f);
	}

    private int HealthPercentage()
    {
        return (int)((enemyReference.currentHealth * 100) / enemyReference.basicStats.getMaxHealth());
    }
}
