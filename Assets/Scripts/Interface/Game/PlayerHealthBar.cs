using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour 
{
    public PlayerController playerReference;

	private Image healthBar;

    public Text healthPercentage;

	void Awake()
	{
		healthBar = GetComponent<Image>();
	}

	void Update () 
	{
        healthPercentage.text = HealthPercentage().ToString() + "%";

		healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, playerReference.currentHealth / playerReference.basicStats.getMaxHealth(), 1.0f);
	}

    private int HealthPercentage()
    {
        return (int)((playerReference.currentHealth * 100) / playerReference.basicStats.getMaxHealth());
    }
}
