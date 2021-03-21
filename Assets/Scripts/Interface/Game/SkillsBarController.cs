using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillsBarController : MonoBehaviour 
{

    public Image imgFFNormal, imgFFCYellow, imgFFCRed;
    public Image imgSNormal, imgSCBlue, imgSCGrenn;

    public PlayerController playerReference;

	void Update () 
    {
        ChangeIconController();
	}

    public void ChangeIconController()
    {
        //Force Field Controller
        if (playerReference.forceFieldTypeOfBullet == 1)
        {
            imgFFNormal.enabled = true;

            imgFFCYellow.enabled = false;
            imgFFCRed.enabled = false;
        }
        else if (playerReference.forceFieldTypeOfBullet == 2)
        {
            imgFFCYellow.enabled = true;

            imgFFNormal.enabled = false;
            imgFFCRed.enabled = false;
        }
        else
        {
            imgFFCRed.enabled = true;

            imgFFCYellow.enabled = false;
            imgFFNormal.enabled = false;
        }

        //Sentinela Controller
        if (playerReference.sentinelTypeOfBullet == 1)
        {
            imgSNormal.enabled = true;

            imgSCBlue.enabled = false;
            imgSCGrenn.enabled = false;
        }
        else if (playerReference.sentinelTypeOfBullet == 2)
        {
            imgSCBlue.enabled = true;

            imgSNormal.enabled = false;
            imgSCGrenn.enabled = false;
        }
        else
        {
            imgSCGrenn.enabled = true;

            imgSCBlue.enabled = false;
            imgSNormal.enabled = false;
        }
    }
}
