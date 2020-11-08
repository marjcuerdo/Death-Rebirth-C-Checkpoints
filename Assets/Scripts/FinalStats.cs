using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalStats : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
   	public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = PlayerPrefs.GetInt("Player Score").ToString();
        //timeText.text = PlayerPrefs.GetInt("TimeInc").ToString();
        Debug.Log("TIME: " + PlayerPrefs.GetFloat("Player Score").ToString());
        DisplayTime(PlayerPrefs.GetFloat("TimeInc"));
        
    }

    // display text in UTC format
	void DisplayTime(float timeToDisplay)
    {
    	timeToDisplay += 1;

    	//float fTimeToDisplay = (float) timeToDisplay;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // reset timer when exit game
    public void OnApplicationQuit(){
         PlayerPrefs.SetFloat("TimeRem", 300);
         PlayerPrefs.SetFloat("TimeInc", 0);
         PlayerPrefs.SetInt("Player Score", 0);
         PlayerPrefs.SetInt("Player Health", 5);
         //Debug.Log("Reset score");
    }
}
