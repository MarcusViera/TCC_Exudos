using UnityEngine;
using System.Collections;

public class DeathController : MonoBehaviour 
{
	public void RestartGame()
	{
        Application.LoadLevel("Level_1_01");
	}

	public void ExitGame()
	{
		Application.Quit ();
	}
}
