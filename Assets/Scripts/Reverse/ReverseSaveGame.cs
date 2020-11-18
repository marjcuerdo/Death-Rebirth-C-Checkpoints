using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ReverseSaveGame : MonoBehaviour
{
	public List<bool> boolStates = new List<bool>(); // store active/inactive states of gameobjects
	public GameObject[] allObjects; // store all gameobjects
	public List<Vector3> positions = new List<Vector3>(); // store positions of objects that may have moved
	public List<Quaternion> rotations = new List<Quaternion>(); // store rotations of objects that moved
	public GameObject[] allMovingObjects; // store all gameobjects that move

    public Image saveIcon;

	public Vector3 spawnPoint1; 

	public ReverseHealth hObj;
    public ReverseScore sObj;
    public ReversePlayerMovement gObj;

    public AudioSource saveSound;
    //public AudioClip saveClip;
    private bool isSaving = false;

    void Awake() {
    	// initialize spawn point at beg of level
    	spawnPoint1 = GameObject.Find("Player").transform.position; 
    }
    void Start() {
        saveIcon.enabled = false;
    	// initialize spawn point at beg of level
    	spawnPoint1 = GameObject.Find("Player").transform.position; 
    	
    	allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>(); // all gameobjects in scene
    	allMovingObjects = GameObject.FindGameObjectsWithTag("Enemy"); // enemy objects that moved
    	sObj = GameObject.Find("Player").GetComponent<ReverseScore>();
		hObj = GameObject.Find("Player").GetComponent<ReverseHealth>();
    	gObj = GameObject.Find("Player").GetComponent<ReversePlayerMovement>();
    }

    void Update() {
        if (isSaving) {
            StartCoroutine("Flashback");
        }
    }

    public void Save(Vector3 position) {
    	// remember that a save point exists for this level (for PlayerMovement.cs)
    	gObj.lvlSavePointExists = true;

   		// clear arrays for a new save
   		if (boolStates.Count > 1) {
   			//Debug.Log("clearing");
   			boolStates.Clear();
   			positions.Clear();
   		}

        // save player position
        spawnPoint1 = position; 

        // find all game objects
        foreach (GameObject go in allObjects)
         {
             boolStates.Add(go.activeInHierarchy); // add active/inactive status
         }

        // find gameobjects that may have moved to return to orig position
        foreach (GameObject go in allMovingObjects)
         {
             positions.Add(go.transform.position);
             rotations.Add(go.transform.rotation);
         }

         // save score and health
        PlayerPrefs.SetInt("Player Score", sObj.score);
        PlayerPrefs.SetInt("Player Health", 5); 
        //Debug.Log("setting health to: " + hObj.health);
        PlayerPrefs.SetInt("Extra Hearts", hObj.currentExtraHearts); 
        //Debug.Log("setting extra to: " + hObj.currentExtraHearts);
        PlayerPrefs.SetInt("Took Damage", (hObj.tookDamage ? 1 : 0));

        saveIcon.enabled = true;
        isSaving = true;

        saveSound.Play();
        Debug.Log("Saved!");
    }

    IEnumerator Flashback() {
        if (isSaving) {
            yield return new WaitForSeconds(2f);
            saveIcon.enabled = false;
            isSaving = false;
        }
    }
}
