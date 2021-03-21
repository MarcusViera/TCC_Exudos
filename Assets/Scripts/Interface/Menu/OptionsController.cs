using UnityEngine;
using System.Collections;

public class OptionsController : MonoBehaviour 
{
	public GameObject soundPanel, controlsPanel, videoPanel;
	
	public void SoundButton()
	{
		if(controlsPanel.activeSelf)
		{
			controlsPanel.SetActive(false);
			soundPanel.SetActive(true);
		}
		if(videoPanel.activeSelf)
		{
			videoPanel.SetActive(false);
			soundPanel.SetActive(true);
		}
		if(soundPanel.activeSelf)
		{
			soundPanel.SetActive(false);
		}
		else
		{
			soundPanel.SetActive(true);
		}
	}

	public void ControlsButton()
	{
		if(soundPanel.activeSelf)
		{
			soundPanel.SetActive(false);
			controlsPanel.SetActive(true);
		}
		if(videoPanel.activeSelf)
		{
			videoPanel.SetActive(false);
			controlsPanel.SetActive(true);
		}
		if(controlsPanel.activeSelf)
		{
			controlsPanel.SetActive(false);
		}
		else
		{
			controlsPanel.SetActive(true);
		}
	}

	public void VideoButton()
	{
		if(soundPanel.activeSelf)
		{
			soundPanel.SetActive(false);
			videoPanel.SetActive(true);
		}
		if(controlsPanel.activeSelf)
		{
			controlsPanel.SetActive(false);
			videoPanel.SetActive(true);
		}
		if(videoPanel.activeSelf)
		{
			videoPanel.SetActive(false);
		}
		else
		{
			videoPanel.SetActive(true);
		}
	}
}
