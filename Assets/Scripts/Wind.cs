using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
	public CharacterController2D controller;

	bool windIsBlowing = false;
	bool timesUp = false;

    void Start()
    {
		StartCoroutine("BlowingWind");
	}

	void FixedUpdate() {
		if (windIsBlowing) {
			Debug.Log("adding wind");
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
		    yield return new WaitForSeconds(1);
		    Debug.Log("TIMER 4");
		    yield return new WaitForSeconds(1);
		    Debug.Log("TIMER 5");
		    yield return new WaitForSeconds(1);
		    Debug.Log("TIMER 6");
		    windIsBlowing = false;
		}
    }

}

