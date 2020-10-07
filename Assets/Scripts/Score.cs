﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    //public int updatedScore;

    public Text scoreText;

    void Awake() {
    	score = PlayerPrefs.GetInt("Player Score");
    }

    void Update() {

    	scoreText.text = "SCORE: " + score.ToString();
    }

    public void AddPoints(int points) {
    	score += points;
    	//updatedScore = score;
    }

    public void OnApplicationQuit(){
         PlayerPrefs.SetInt("Player Score", 0);
         //Debug.Log("Reset score");
    }
}