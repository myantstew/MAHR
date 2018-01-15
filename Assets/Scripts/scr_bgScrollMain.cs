using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_bgScrollMain : MonoBehaviour 
{
    public GameObject hills;
    public GameObject fence;
    public GameObject cloud;
    public static float speed;
    public float fenceSpeed;
    public float cloudSpeed;
    Vector3 hillSpawn = new Vector3(17.85f, -2.3f, 0);
    Vector3 backhillSpawn = new Vector3(17.85f, -0.6f, 0);
    Vector3 cloudSpawn = new Vector3(10.5f, 2.25f, 0);
    Vector3 fenceSpawn = new Vector3(20f, -2f, 0);
    GameObject myCopy;
    bool newBg = false;

	void Start () 
    {
        speed = scr_enemyGenerator.GAMESPEED;
        fenceSpeed = speed - 0.01f;
        cloudSpeed = -0.005f;
	}
	
	void Update () 
    {
        float mySpeed;
        if (this.gameObject.tag == "fence")
            mySpeed = fenceSpeed;
        else if (this.gameObject.tag == "clouds")
            mySpeed = cloudSpeed;
        else if (this.gameObject.tag == "building" || this.gameObject.tag == "pigpen")
            mySpeed = speed - 0.005f;
        else if (this.gameObject.tag == "backhills")
            mySpeed = speed + 0.005f;
        else
            mySpeed = speed;
        transform.Translate(mySpeed, 0, 0);
        if (this.gameObject.tag == "hill" && transform.position.x < -10 && newBg == false)
            newHill(hillSpawn);
        else if (this.gameObject.tag == "clouds" && transform.position.x < -2.5f && newBg == false)
            newHill(cloudSpawn);
        else if (this.gameObject.tag == "backhills" && transform.position.x < -10 && newBg == false)
            newHill(backhillSpawn);
        else if (this.gameObject.tag == "fence" && transform.position.x < -11.5f && newBg == false)
            newFence();
        if (this.transform.position.x < -20)
            Destroy(this.gameObject);
	}

    void newHill(Vector3 hillSpawn)
    {
        myCopy = Instantiate(hills, hillSpawn, transform.rotation);
        newBg = true;
    }
    void newFence()
    {
        myCopy = Instantiate(fence, fenceSpawn, transform.rotation);
        newBg = true;
    }
}
