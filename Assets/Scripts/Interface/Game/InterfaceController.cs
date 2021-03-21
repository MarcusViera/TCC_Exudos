using UnityEngine;
using System.Collections;

public class InterfaceController : MonoBehaviour 
{
    //Variaveis para controle de métodos
    public StatusController statusControllerReference;
    public LevelUpController levelUpControllerReference;
    public CrystalController cystalControllerReference;
    public SkillsController skillsCrontollerReference;

    //Variaveis para controle de transição de Telas
    public bool activedStatusPanel, activedSkillsPanel, activedMenuPanel;
    public GameObject statusPanel, skillsPanel, menuPanel;
    public GameObject levelUpButton;

    void FixedUpdate()
    {
        statusControllerReference.ShowingStatus();

        levelUpControllerReference.ActivateButtonsStatusUpgrade();
        
        cystalControllerReference.ShowingNumbersOfCrystals();
        cystalControllerReference.ActivateBtnCrystalsUpgrade();

        skillsCrontollerReference.ManagerUnlockSkills();
    }

	void Update () 
    {
        ActivedWindowsController();
	}

    void ActivedWindowsController()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!activedSkillsPanel)
            {
                skillsPanel.SetActive(true);
                levelUpButton.SetActive(false);
                activedSkillsPanel = true;
            }
            else
            {
                skillsPanel.SetActive(false);
                activedSkillsPanel = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (!activedStatusPanel)
            {
                statusPanel.SetActive(true);
                activedStatusPanel = true;
            }
            else
            {
                statusPanel.SetActive(false);
                activedStatusPanel = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!activedMenuPanel)
            {
                menuPanel.SetActive(true);
                activedMenuPanel = true;
            }
            else
            {
                menuPanel.SetActive(false);
                activedMenuPanel = false;
            }
        }
    }

    public void BtnSkillPanel ()
    {
        if (!activedSkillsPanel)
        {
            skillsPanel.SetActive(true);
            levelUpButton.SetActive(false);
            activedSkillsPanel = true;
        }
        else
        {
            skillsPanel.SetActive(false);
            activedSkillsPanel = false;
        }
    }

    public void BtnCharacterPanel()
    {
        if (!activedStatusPanel)
        {
            statusPanel.SetActive(true);
            activedStatusPanel = true;
        }
        else
        {
            statusPanel.SetActive(false);
            activedStatusPanel = false;
        }
    }

    //Métodos do painel Menu
    public void BtnMenuPanel()
    {
        if (!activedMenuPanel)
        {
            menuPanel.SetActive(true);
            activedMenuPanel = true;
        }
        else
        {
            menuPanel.SetActive(false);
            activedMenuPanel = false;
        }
    }
    public void BtnOptions()
    {
        //Pesquisar como fazer isso.
    }
    public void BtnExitGame()
    {
        Application.Quit();
    }

    public void LevelUpButtonPress()
    {
        skillsPanel.SetActive(true);
        activedSkillsPanel = true;
        levelUpButton.SetActive(false);
    }
}
