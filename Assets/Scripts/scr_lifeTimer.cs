using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;
using System.Timers;
using UnityEngine.UI;

public class scr_lifeTimer : MonoBehaviour 
{
    public static Text timeDisplay;
    public static DateTime currentTime;
    public static TimeSpan myTimeSpan;

    public static bool isCounting;
    public static DateTime targetTime;

	// Use this for initialization
	void Start () 
    {
        DontDestroyOnLoad(this.gameObject);
        timeDisplay = GetComponent<Text>();
    }
	
    // Update is called once per frame
	void Update () 
    {
        if (isCounting)
        {
            myTimeSpan = targetTime.Subtract(DateTime.Now);
            DateTime theTime = Convert.ToDateTime(myTimeSpan.ToString());
            timeDisplay.text = theTime.ToString("mm:ss");
            currentTime = DateTime.Now;

            if (currentTime >= targetTime)
                TimeExpired();
        }
	}

    public static void TimeExpired()
    {
        isCounting = false;
        scr_gameController.LIFEBANK += 1;
        timeDisplay.text = "Time is up!";
    }

    public static void StartTimer()
    {
        isCounting = true;
        targetTime = DateTime.Now.AddMinutes(15f);
        currentTime = DateTime.Now;
    }
}
