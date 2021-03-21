using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour 
{
	public GameObject menuPrincipal, options, credits;
	public AudioSource buttonOverSound, buttonPressSound;
	
	public void NewGameButton()
	{
        Application.LoadLevel("Level_1_01");
	}

	public void OptionsButton()
	{
		menuPrincipal.SetActive (false);
		options.SetActive (true);
	}

	public void CreditsButton()
	{
		menuPrincipal.SetActive (false);
		credits.SetActive (true);
	}
	
	public void ExitButton()
	{
		Application.Quit ();
	}

	public void BackMenuPrincipalButton()
	{
		if(credits.activeSelf)
		{
			credits.SetActive (false);
			menuPrincipal.SetActive (true);
		}

		if(options.activeSelf)
		{
			options.SetActive (false);
			menuPrincipal.SetActive (true);
		}
	}

	public void ButtonOverSound()
	{
		buttonOverSound.Play ();
	}

	public void ButtonOPressSound()
	{
		buttonPressSound.Play ();
	}
}
