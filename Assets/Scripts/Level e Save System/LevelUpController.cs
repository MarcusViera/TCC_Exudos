using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelUpController : MonoBehaviour 
{
	public GameObject activeButtons, bntlevelUp;

	public PlayerController playerReference;
	public Text pointsLabel, dexterityLabel, vitalityLabel, energyLabel, protectionLabel;

    //Upgrade de Status Controller 
	public void IncreaseDexterity()
	{
		if(GameDesign.CURRENT_POINTS >= 1)
		{
			playerReference.basicStats.dexterity += 1;
			GameDesign.CURRENT_POINTS -= 1;
		}
	}
	public void DecreaseDexterity()
	{
		if(GameDesign.CURRENT_POINTS < 5)
		{
			playerReference.basicStats.dexterity -= 1;
			GameDesign.CURRENT_POINTS += 1;
		}
	}

	public void IncreaseVitality()
	{
		if(GameDesign.CURRENT_POINTS >= 1)
		{
			playerReference.basicStats.vitality += 1;
			GameDesign.CURRENT_POINTS -= 1;
		}
	}
	public void DecreaseVitality()
	{
		if(GameDesign.CURRENT_POINTS < 5)
		{
			playerReference.basicStats.vitality -= 1;
			GameDesign.CURRENT_POINTS += 1;
		}
	}

	public void IncreaseEnergy()
	{
		if(GameDesign.CURRENT_POINTS >= 1)
		{
			playerReference.basicStats.energy += 1;
			GameDesign.CURRENT_POINTS -= 1;
		}
	}
	public void DecreaseEnergy()
	{
		if(GameDesign.CURRENT_POINTS < 5)
		{
			playerReference.basicStats.energy -= 1;
			GameDesign.CURRENT_POINTS += 1;
		}
	}

	public void IncreaseProtection()
	{
		if(GameDesign.CURRENT_POINTS >= 1)
		{
			playerReference.basicStats.protection += 1;
			GameDesign.CURRENT_POINTS -= 1;
		}
	}
	public void DecreaseProtection()
	{
		if(GameDesign.CURRENT_POINTS < 5)
		{
			playerReference.basicStats.protection -= 1;
			GameDesign.CURRENT_POINTS += 1;
		}
	}

	public void ActivateButtonsStatusUpgrade()
	{
		if(GameDesign.CURRENT_POINTS >= 1)
		{
			activeButtons.SetActive(true);
            bntlevelUp.SetActive(true);
		}
		else
		{
			activeButtons.SetActive(false);
            bntlevelUp.SetActive(false);
		}
	}
}
