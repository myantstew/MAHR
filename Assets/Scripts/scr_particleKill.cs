using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_particleKill : MonoBehaviour 
{
    public string myName;
    public SpriteRenderer mySprite;
    float myScaleX;
    float myScaleY;
    Vector2 startScale;

    float fadeSpeed = 1f;
    float fadeTime = 1f;
    float fader = 1;

	// Use this for initialization
	void Start () 
    {
        myScaleX = transform.localScale.x;
        myScaleY = transform.localScale.y;
        startScale = new Vector2(myScaleX, myScaleY);
        if (myName == "explosion")
            StartCoroutine("Expand");
        else if (myName == "pigMeat")
            StartCoroutine("Death");
        else if (myName == "ghost" || myName == "egg")
            StartCoroutine("Fade");
        else if (myName == "bolt" || myName == "splash")
            StartCoroutine("Fade");
        else
            StartCoroutine("Death");
	}
    void Update()
    {
        if (myName == "ghost")
            transform.Translate(0, 0.005f, 0);
    }

	// Update is called once per frame
    IEnumerator Expand() 
    {
        Vector2 resize = new Vector2(myScaleX, myScaleY);
        if (resize.x < startScale.x + 0.5f)
        {
            myScaleX = myScaleX + 0.15f;
            myScaleY = myScaleY + 0.15f;
            resize = new Vector2(myScaleX, myScaleY);
            transform.localScale = resize;
            yield return new WaitForSeconds(0.075f);
            StartCoroutine("Expand");
        }
        else
        {
            yield return new WaitForSeconds(0.25f);
            StartCoroutine("Fade");
        }

	}
    IEnumerator Fade()
    {
        if (fader > 0)
        {
            if(myName == "ghost")
                fader = fader - 0.05f;
            else if(myName == "egg")
                fader = fader - 0.1f;
            else if(myName == "bolt")
                fader = fader - 0.15f;
            else
                fader = fader - 0.25f;
            mySprite.color = new Color(1f, 1f, 1f, fader);
            yield return new WaitForSeconds(0.1f); 
            StartCoroutine("Fade");
        }
        else
            Killme();
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(4f);
        Killme();
    }
    void Killme()
    {
        Destroy(this.gameObject);
    }
}
