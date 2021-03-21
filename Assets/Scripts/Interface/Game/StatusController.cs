using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class StatusController : MonoBehaviour 
{
	public Text txtLevel, txtDamage, txtHealht, txtEnergy, txtShield, txtDexterity, txtVitality,
        txtPoints, txtMana, txtProtection;
	public PlayerController playerReference;

    public void ShowingStatus()
    {
        txtLevel.text = playerReference.level.ToString();
        txtDamage.text = playerReference.basicStats.getDamage().ToString();
        txtHealht.text = playerReference.basicStats.getMaxHealth().ToString();
        txtEnergy.text = GameDesign.MAX_ENERGY.ToString();
        txtShield.text = Math.Round(playerReference.basicStats.getMaxShield(), 2).ToString();
        txtDexterity.text = playerReference.basicStats.dexterity.ToString();
        txtPoints.text = GameDesign.CURRENT_POINTS.ToString();
        txtMana.text = playerReference.currentEnergy.ToString();
        txtVitality.text = playerReference.basicStats.vitality.ToString();
        txtProtection.text = Math.Round((playerReference.basicStats.protection * 100), 2).ToString(); 
    }
}
