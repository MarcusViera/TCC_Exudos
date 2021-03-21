using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CrystalController : MonoBehaviour 
{
    public Text crystalGreen, crystalBlue, crystalYellow, crystalRed;
    public PlayerController playerReference;
    public GameObject btnCrystalBlueUpgrade, btnCrystalRedUpgrade, btnCrystalGreenUpgrade, btnCrystalYellowUpgrade;

    public void BtnCrystalBlueUpgrade()
    {
        playerReference.basicStats.armorDexterity += GameDesign.ARMOR_DEXTERITY_UPGRADE_POTINS;
        playerReference.numberOfCristalBlue -= GameDesign.ARMOR_DEXTERITY_CRYSTAL_BLUE_UNLOCK;
    }

    public void BtnCrystalRedUpgrade()
    {
        playerReference.basicStats.armorVitality += GameDesign.ARMOR_VITALITY_UPGRADE_POTINS;
        playerReference.numberOfCristalRed -= GameDesign.ARMOR_VITALITY_CRYSTAL_RED_UNLOCK;
    }

    public void BtnCrystalYellowUpgrade()
    {
        playerReference.basicStats.armorEnergy += GameDesign.ARMOR_ENERGY_UPGRADE_POTINS;
        playerReference.numberOfCristalYelow -= GameDesign.ARMOR_ENERGY_CRYSTAL_YELLOW_UNLOCK;
    }

    public void BtnCrystalGreenUpgrade()
    {
        playerReference.basicStats.armorProtection += GameDesign.ARMOR_PROTECTION_UPGRADE_POTINS;
        playerReference.numberOfCristalGreen -= GameDesign.ARMOR_PROTECTION_CRYSTAL_GREEN_UNLOCK;
    }


    public void ShowingNumbersOfCrystals()
    {
        crystalGreen.text = playerReference.numberOfCristalGreen.ToString();
        crystalBlue.text = playerReference.numberOfCristalBlue.ToString();
        crystalYellow.text = playerReference.numberOfCristalYelow.ToString();
        crystalRed.text = playerReference.numberOfCristalRed.ToString();
    }

    public void ActivateBtnCrystalsUpgrade()
    {
        //Ativar Botão cristal azul
        if (playerReference.numberOfCristalBlue >= GameDesign.ARMOR_DEXTERITY_CRYSTAL_BLUE_UNLOCK)
        {
            btnCrystalBlueUpgrade.SetActive(true);
        }
        else
        {
            btnCrystalBlueUpgrade.SetActive(false);
        }

        //Ativar Botão cristal vermelho
        if (playerReference.numberOfCristalRed >= GameDesign.ARMOR_VITALITY_CRYSTAL_RED_UNLOCK)
        {
            btnCrystalRedUpgrade.SetActive(true);
        }
        else
        {
            btnCrystalRedUpgrade.SetActive(false);
        }

        //Ativar Botão cristal amarelo
        if (playerReference.numberOfCristalYelow >= GameDesign.ARMOR_ENERGY_CRYSTAL_YELLOW_UNLOCK)
        {
            btnCrystalYellowUpgrade.SetActive(true);
        }
        else
        {
            btnCrystalYellowUpgrade.SetActive(false);
        }

        //Ativar Botão cristal verde
        if (playerReference.numberOfCristalGreen >= GameDesign.ARMOR_PROTECTION_CRYSTAL_GREEN_UNLOCK)
        {
            btnCrystalGreenUpgrade.SetActive(true);
        }
        else
        {
            btnCrystalGreenUpgrade.SetActive(false);
        }
    }
}
