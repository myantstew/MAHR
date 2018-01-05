using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_storeController : MonoBehaviour 
{
    public Image lifeAlertBox;
    public Button lifeAlertButtonOK;
    public Button lifeAlertButtonCancel;
    public Text lifeAlertText;
    public Text lifeAlertOKText;
    public Text lifeAlertCancelText;

    public Image coinAlertBox;
    public Button coinAlertButtonOK;
    public Button coinAlertButtonCancel;
    public Text coinAlertText;
    public Text coinAlertOKText;
    public Text coinAlertCancelText;

    //errorbutton
    public Image errorAlertBox;
    public Button errorAlertButtonOK;
    public Text errorAlertText;
    public Text errorAlertOKText;


    // Use this for initialization
	void Start () 
    {
        CloseAlertBox();
	}
	
	// Update is called once per frame
	public void ShowLifeAlert() 
    {
        CloseAlertBox();
        lifeAlertBox.enabled = true;
        lifeAlertButtonOK.image.enabled = true;
        lifeAlertButtonCancel.image.enabled = true;
        lifeAlertText.enabled = true;
        lifeAlertOKText.enabled = true;
        lifeAlertCancelText.enabled = true;
	}

    public void ShowCoinAlert()
    {
        CloseAlertBox();
        coinAlertBox.enabled = true;
        coinAlertButtonOK.image.enabled = true;
        coinAlertButtonCancel.image.enabled = true;
        coinAlertText.enabled = true;
        coinAlertOKText.enabled = true;
        coinAlertCancelText.enabled = true;
    }

    public void ShowErrorAlert(int errorType)
    {
        CloseAlertBox();
        if (errorType == 0)
        {
            errorAlertBox.enabled = true;
            errorAlertButtonOK.image.enabled = true;
            errorAlertText.text = "Error: Not Enough Coins!";
            errorAlertText.enabled = true;
            errorAlertOKText.enabled = true;
        }
        else if (errorType == 1)
        {
            errorAlertBox.enabled = true;
            errorAlertButtonOK.image.enabled = true;
            errorAlertText.text = "Error: 10 Life Maximum!";
            errorAlertText.enabled = true;
            errorAlertOKText.enabled = true;
        }
        else
        {
            errorAlertBox.enabled = true;
            errorAlertButtonOK.image.enabled = true;
            errorAlertText.text = "Error: Purchase Failed!";
            errorAlertText.enabled = true;
            errorAlertOKText.enabled = true;
        }
    }

    public void GetLife()
    {
        if (scr_gameController.COINS >= 100)
        {
            if (scr_gameController.LIFEBANK < 10)
            {
                scr_gameController.LIFEBANK += 1;
                scr_gameController.COINS -= 100;
                CloseAlertBox();
            }
            else
                ShowErrorAlert(1);
        }
        else
        {
            ShowErrorAlert(0);
        }

    }

    public void GetCoins()
    {
        scr_gameController.COINS += 500;
        CloseAlertBox();
    }

    public void CloseAlertBox()
    {
        lifeAlertBox.enabled = false;
        lifeAlertButtonOK.image.enabled = false;
        lifeAlertButtonCancel.image.enabled = false;
        lifeAlertText.enabled = false;
        lifeAlertOKText.enabled = false;
        lifeAlertCancelText.enabled = false;

        coinAlertBox.enabled = false;
        coinAlertButtonOK.image.enabled = false;
        coinAlertButtonCancel.image.enabled = false;
        coinAlertText.enabled = false;
        coinAlertOKText.enabled = false;
        coinAlertCancelText.enabled = false;

        errorAlertBox.enabled = false;
        errorAlertButtonOK.image.enabled = false;
        errorAlertText.enabled = false;
        errorAlertOKText.enabled = false;
    }
}
