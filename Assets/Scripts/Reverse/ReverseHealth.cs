using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReverseHealth : MonoBehaviour
{
    public int health = 5;
    public int numOfHearts = 5;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public ReversePlayerMovement gObj;


    void Awake() {

        gObj = GameObject.Find("Player").GetComponent<ReversePlayerMovement>();
    }

    void Update() {

        if (gObj.isNewGame == false) {
           // Debug.Log("getting player health: " + PlayerPrefs.GetInt("Player Health").ToString());
            health = PlayerPrefs.GetInt("Player Health");
            //Debug.Log("again player health: " + PlayerPrefs.GetInt("Player Health").ToString());
            gObj.isNewGame = true;
        }

        // player's health relates to number of hearts displayed
    	if (health > numOfHearts) {
    		health = numOfHearts;
    	}

    	for (int i=0; i < hearts.Length; i++) {

    		if (i < health) {
    			hearts[i].sprite = fullHeart; // use full heart image 
    		} else {
    			hearts[i].sprite = emptyHeart; // use empty heart when health decreated
    		}

    		if (i < numOfHearts) {
    			hearts[i].enabled = true;
    		} else {
    			hearts[i].enabled = false;
    		}
    	}
    }

    // decrease health when taking damange
    public void TakeDamage(int damage) {
    	health -= damage;
    }

    // add health with health pack
    public void AddHealth() {
        health += 1;

    }

    // reset health on game exit
    public void OnApplicationQuit(){
         PlayerPrefs.SetInt("Player Health", 5);

         //Debug.Log("Reset health");
    }

}
