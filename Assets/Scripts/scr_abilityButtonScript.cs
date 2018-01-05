using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_abilityButtonScript : MonoBehaviour 
{

    Button abilityButton;
    public Sprite[] myImages;
    public GameObject player;
    public scr_playerScript playerScript;
    Image myImage;

    public Image greenPanel;

    float chargeScale = 1;
    bool resetting = false;

	// Use this for initialization
	void Start () 
    {
        abilityButton = GetComponent<Button>();
        myImage = GetComponent<Image>();
        Vector3 half = new Vector3(1f, 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!player)
        {
            player = GameObject.FindWithTag("Player");
            if(player)
                playerScript = player.GetComponent<scr_playerScript>();
        }

        if (playerScript.CanShoot == true)
            greenPanel.color = Color.white;
        else
            greenPanel.color = Color.black;
            
        
        if (playerScript.iHasEel == true)
        {
            if (playerScript.CanShoot == true)
                myImage.sprite = myImages[1];
            else
                myImage.sprite = myImages[2];
  
        }
        else if (playerScript.iHasMudbug == true)
        {
            if (playerScript.CanShoot == true)
                myImage.sprite = myImages[3];
            else
                myImage.sprite = myImages[4];
        }
        else if (playerScript.iHasCat == true)
        {
            if (playerScript.CanShoot == true)
                myImage.sprite = myImages[5];
            else
                myImage.sprite = myImages[6];
        }
        else
            myImage.sprite = myImages[0];
	}

    public void Shoot() 
    {
        if (!playerScript)
            playerScript = GameObject.FindWithTag("Player").GetComponent<scr_playerScript>();
        playerScript.Shoot();
    }
}
