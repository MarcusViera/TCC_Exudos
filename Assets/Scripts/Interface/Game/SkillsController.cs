using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillsController : MonoBehaviour
{
    public PlayerController playerReference;

    //Variaveis para os botões das Armas
    public GameObject btnWeapon01, btnWeapon02;

    //Variaveis para o controle de trasições.
    public GameObject btnSentinel, btnForceField;
    private bool forceFieldActived, sentinelActived;
    
    //Variaveis para o Destravamento das habilidades
    public GameObject btnUnlockForceFieldCrystalYellow, btnUnlockForceFieldCrystalRed, btnUnlockSentinelCrystalBlue,
        btnUnlockSentinelCrystalGreen;
    public GameObject btnCrystakYellow, btnCrystalRed, btnCrystalBlue, btnCrystalGreen;    

    //Variaveis para a troca de habilidades  
    //Force Field
    public Image imgForceField, imgForceFieldCrystalYellow, imgForceFieldCrystalRed;
    private bool activedForceFieldNormal, activedForceFieldCrystalYellow, activedForceFieldCrystalRed;

    //Sentinel
    public Image imgSentinel, imgSentinelCrystalBlue, imgSentinelCrystalGreen;
    private bool activedSentinelNormal, activedSentinelCrystalBlue, activedSentinelCrystalGreen;

	void Start () 
    {
        forceFieldActived = false;
        sentinelActived = false;
	}

    //Métodos para o escolha de habilidades.
    //Campo de Força
    public void BtnForceFieldNormal()
    {
        if (activedForceFieldCrystalYellow)
        {
            activedForceFieldCrystalYellow = false;
            imgForceFieldCrystalYellow.enabled = false;

            activedForceFieldNormal = true;
            playerReference.forceFieldTypeOfBullet = 1;
            imgForceField.enabled = true;
            
        }
        else if (activedForceFieldCrystalRed)
        {
            activedForceFieldCrystalRed = false;
            imgForceFieldCrystalRed.enabled = false;

            activedForceFieldNormal = true;
            playerReference.forceFieldTypeOfBullet = 1;
            imgForceField.enabled = true;
        }
        else
        {
            activedForceFieldNormal = true;
            playerReference.forceFieldTypeOfBullet = 1;
            imgForceField.enabled = true;
        }
    }
    public void BtnForceFieldCrystalYellow()
    {
        if (activedForceFieldNormal)
        {
            activedForceFieldNormal = false;
            imgForceField.enabled = false;

            activedForceFieldCrystalYellow = true;
            playerReference.forceFieldTypeOfBullet = 2;
            imgForceFieldCrystalYellow.enabled = true;
            
        }
        else if (activedForceFieldCrystalRed)
        {
            activedForceFieldCrystalRed = false;
            imgForceFieldCrystalRed.enabled = false;

            activedForceFieldCrystalYellow = true;
            playerReference.forceFieldTypeOfBullet = 2;
            imgForceFieldCrystalYellow.enabled = true;
        }
        else
        {
            activedForceFieldCrystalYellow = true;
            playerReference.forceFieldTypeOfBullet = 2;
            imgForceFieldCrystalYellow.enabled = true;
        }
    }
    public void BtnForceFieldCrystalRed()
    {
        if (activedForceFieldNormal)
        {
            activedForceFieldNormal = false;
            imgForceField.enabled = false;

            activedForceFieldCrystalRed = true;
            playerReference.forceFieldTypeOfBullet = 3;
            imgForceFieldCrystalRed.enabled = true;
        }
        else if (activedForceFieldCrystalYellow)
        {
            activedForceFieldCrystalYellow = false;
            imgForceFieldCrystalYellow.enabled = false;

            activedForceFieldCrystalRed = true;
            playerReference.forceFieldTypeOfBullet = 3;
            imgForceFieldCrystalRed.enabled = true;
        }
        else
        {
            activedForceFieldCrystalRed = true;
            playerReference.forceFieldTypeOfBullet = 3;
            imgForceFieldCrystalRed.enabled = true;
        }
    }

    //Sentinela
    public void BtnSentinelNomral()
    {
        if (activedSentinelCrystalBlue)
        {
            activedSentinelCrystalBlue = false;
            imgSentinelCrystalBlue.enabled = false;

            activedSentinelNormal = true;
            playerReference.sentinelTypeOfBullet = 1;
            imgSentinel.enabled = true;
        }
        else if (activedSentinelCrystalGreen)
        {
            activedSentinelCrystalGreen = false;
            imgSentinelCrystalGreen.enabled = false;

            activedSentinelNormal = true;
            playerReference.sentinelTypeOfBullet = 1;
            imgSentinel.enabled = true;
        }
        else
        {
            activedSentinelNormal = true;
            playerReference.sentinelTypeOfBullet = 1;
            imgSentinel.enabled = true;
        }
    }
    public void BtnSentinelCrystalBlue()
    {
        if (activedSentinelNormal)
        {
            activedSentinelNormal = false;
            imgSentinel.enabled = false;

            activedSentinelCrystalBlue = true;
            playerReference.sentinelTypeOfBullet = 2;
            imgSentinelCrystalBlue.enabled = true;
        }
        else if (activedSentinelCrystalGreen)
        {
            activedSentinelCrystalGreen = false;
            imgSentinelCrystalGreen.enabled = false;

            activedSentinelCrystalBlue = true;
            playerReference.sentinelTypeOfBullet = 2;
            imgSentinelCrystalBlue.enabled = true;
        }
        else
        {
            activedSentinelCrystalBlue = true;
            playerReference.sentinelTypeOfBullet = 2;
            imgSentinelCrystalBlue.enabled = true;
        }
    }
    public void BtnSentinelCrystalGreen()
    {
        if (activedSentinelNormal)
        {
            activedSentinelNormal = false;
            imgSentinel.enabled = false;

            activedSentinelCrystalGreen = true;
            playerReference.sentinelTypeOfBullet = 3;
            imgSentinelCrystalGreen.enabled = true;
        }
        else if (activedSentinelCrystalBlue)
        {
            activedSentinelCrystalBlue = false;
            imgSentinelCrystalBlue.enabled = false;

            activedSentinelCrystalGreen = true;
            playerReference.sentinelTypeOfBullet = 3;
        }
        else
        {
            activedSentinelCrystalGreen = true;
            playerReference.sentinelTypeOfBullet = 3;
            imgSentinelCrystalGreen.enabled = true;
        }

    }



    ///Métodos para os botões de navegação
    public void BtnForceField()
    {
        if(!forceFieldActived)
        {
            btnForceField.SetActive(true);
            forceFieldActived = true;
        }
        else
        {
            btnForceField.SetActive(false);
            forceFieldActived = false;
        }
    }
    public void BtnSentinel()
    {
        if (!sentinelActived)
        {
            btnSentinel.SetActive(true);
            sentinelActived = true;
        }
        else
        {
            btnSentinel.SetActive(false);
            sentinelActived = false ;
        }
    }


    ///Método para destravar habilidades
    //Controle dos numeros de cristais
    public void ManagerUnlockSkills()
    {
        //Campo de Força
        if(playerReference.numberOfCristalYelow >= GameDesign.FORCE_FIELD_CRYSTAL_YELLOW_NUMBER_UNLOCK)
        {
            if (btnUnlockForceFieldCrystalYellow != null)
            {
                btnUnlockForceFieldCrystalYellow.SetActive(true);
            }
           
        }
        if (playerReference.numberOfCristalRed >= GameDesign.FORCE_FIELD_CRYSTAL_RED_NUMBER_UNLOCK)
        {
            if (btnUnlockForceFieldCrystalYellow != null)
            {
                btnUnlockForceFieldCrystalRed.SetActive(true);
            }
        }

        //Sentinel
        if (playerReference.numberOfCristalBlue >= GameDesign.SENTINEL_CRYSTAL_BLUE_NUMBER_UNLOCK)
        {
            if (btnUnlockSentinelCrystalBlue != null)
            {
                btnUnlockSentinelCrystalBlue.SetActive(true);
            }
            
        }
        if (playerReference.numberOfCristalGreen >= GameDesign.SENTINEL_CRYSTAL_GREEN_NUMBER_UNLOCK)
        {
            if (btnUnlockSentinelCrystalGreen != null)
            {
                btnUnlockSentinelCrystalGreen.SetActive(true);
            }
        }
    }

    //Métodos para ativar os botões de habilidades.
    public void BtnUnlockForceFileldCrystalYelllow()
    {
        btnCrystakYellow.SetActive(true);
        playerReference.numberOfCristalYelow -= GameDesign.FORCE_FIELD_CRYSTAL_YELLOW_NUMBER_UNLOCK;
        Destroy(btnUnlockForceFieldCrystalYellow);
    }
    public void BtnUnlockForceFileldCrystalRed()
    {
        btnCrystalRed.SetActive(true);
        playerReference.numberOfCristalRed -= GameDesign.FORCE_FIELD_CRYSTAL_RED_NUMBER_UNLOCK;
        Destroy(btnUnlockForceFieldCrystalRed);
    }

    public void BtnUnlockSentinelaCrystalBlue()
    {
        btnCrystalBlue.SetActive(true);
        playerReference.numberOfCristalBlue -= GameDesign.SENTINEL_CRYSTAL_BLUE_NUMBER_UNLOCK;
        Destroy(btnUnlockSentinelCrystalBlue);
    }
    public void BtnUnlockSentinelaCrystalGreen()
    {
        btnCrystalGreen.SetActive(true);
        playerReference.numberOfCristalGreen -= GameDesign.SENTINEL_CRYSTAL_GREEN_NUMBER_UNLOCK;
        Destroy(btnUnlockSentinelCrystalGreen);
    }

    //Métodos para o controle dos botões da arma.
    public void BtnShowWeaponPanel01()
    {
        btnWeapon01.SetActive(true);
    }
    public void BtnNotShowWeaponPanel01()
    {
        btnWeapon01.SetActive(false);
    }

    public void BtnShowWeaponPanel02()
    {
        btnWeapon02.SetActive(true);
    }
    public void BtnNotShowWeaponPanel02()
    {
        btnWeapon02.SetActive(false);
    }

}
