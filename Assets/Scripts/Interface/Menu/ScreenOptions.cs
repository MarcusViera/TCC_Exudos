using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenOptions : MonoBehaviour 
{
    //private resolution resolutions;
    //private float teste;
    //public text resolutiontext;
    //public slider resolutionslider;

    void Start()
    {
        Resolution[] resolutions = Screen.resolutions;
        foreach (Resolution res in resolutions)
        {
            print(res.width + "x" + res.height);
        }
        Screen.SetResolution(resolutions[0].width, resolutions[0].height, true);
    }
	
    //void Update () 
    //{
    //    resolutionText.text = teste.ToString();
    //}
}
