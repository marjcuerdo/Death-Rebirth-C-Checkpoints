using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{

	//public AudioSource windAudio;

	public CharacterController2D controller;

	public GameObject[] windObjs;
	public Animator[] windAnimsArray;

	public bool windIsBlowing = false;
	bool timesUp = false;

    void Start()
    {
    	windObjs = GameObject.FindGameObjectsWithTag("Wind");
    	foreach (GameObject go in windObjs) {
    			go.GetComponent<Animator>().enabled = false;
    	}
		StartCoroutine("BlowingWind");
	}

	void FixedUpdate() {
		if (windIsBlowing) {
			//Debug.Log("adding wind");
			//windAudio.Play();
		    controller.GetComponent<Rigidbody2D>().AddForce(new Vector3(-50f,0f,0f), ForceMode2D.Force);
		}
    }

    IEnumerator BlowingWind() {
    	while (!timesUp) {
	    	yield return new WaitForSeconds(1);
		    Debug.Log("TIMER 1");
		    yield return new WaitForSeconds(1);
		    Debug.Log("TIMER 2");
		    yield return new WaitForSeconds(1);
		    Debug.Log("TIMER 3");
		    windIsBlowing = true;
		    /*for (int i=0; i<windAnimsArray.Length; i++) {
		    	windAnimsArray[i].enabled = true;
		    }*/
		    foreach (GameObject go in windObjs) {
    			go.GetComponent<Animator>().enabled = true;
    		}
		    yield return new WaitForSeconds(1);
		    Debug.Log("TIMER 4");
		    yield return new WaitForSeconds(1);
		    Debug.Log("TIMER 5");
		    yield return new WaitForSeconds(1);
		    Debug.Log("TIMER 6");
		    /*for (int i=0; i<windAnimsArray.Length; i++) {
		    	windAnimsArray[i].enabled = false;
		    }*/
		    foreach (GameObject go in windObjs) {
    			go.GetComponent<Animator>().enabled = false;
    		}
		    windIsBlowing = false;
		}
    }

}

