using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerManaBar : MonoBehaviour 
{
    public PlayerController playerReference;
	private Image manaBar;
    public Text manaPercentage;
	
	void Awake()
	{
		manaBar = GetComponent<Image>();
	}

	void Update () 
	{
        manaPercentage.text = ((playerReference.currentEnergy * 100) / GameDesign.MAX_ENERGY).ToString() + "%";

        manaBar.fillAmount = Mathf.Lerp(manaBar.fillAmount, playerReference.currentEnergy / GameDesign.MAX_ENERGY, 0.075f);
	}
}
