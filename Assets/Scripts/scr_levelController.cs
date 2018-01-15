using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_levelController : MonoBehaviour 
{
    public GameObject[] someObject;
    public GameObject[] someBuilding;
    public GameObject someSilo;
    public scr_gameMusic myMusic;
    public int musicChoice;

	// Use this for initialization
	void Start () 
    {
        InvokeRepeating("spawnObject", 0.4f, 2.5f);
        InvokeRepeating("spawnBuilding", 0.75f, 10f);
        InvokeRepeating("spawnSilo", 1.25f, 15f);

        myMusic = GameObject.FindWithTag("musicbox").GetComponent<scr_gameMusic>();
        myMusic.ChangeMusic(musicChoice);
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void spawnObject()
    {
        int x = Random.Range(0, 3);
        Vector3 spawnPosition = new Vector3(8, -1.6f, 0);
        GameObject newObject = Instantiate(someObject[x], spawnPosition, transform.rotation) as GameObject;
    }
    void spawnBuilding()
    {
        int y = Random.Range(0, 3);
        Vector3 spawnPosition = new Vector3(8, -2.2f, 0);
        GameObject newBuilding = Instantiate(someBuilding[y], spawnPosition, transform.rotation) as GameObject;
    }
    void spawnSilo()
    {
        float height = Random.Range(-5f, -3.75f);
        Vector3 spawnPosition = new Vector3(8, height, 0);
        GameObject newSilo = Instantiate(someSilo, spawnPosition, transform.rotation) as GameObject;
    }
}
