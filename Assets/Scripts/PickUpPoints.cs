﻿using UnityEngine;
using System.Collections;

public class PickUpPoints : MonoBehaviour {

	public int scoreToGive;
	public ScoreManager theScoreManager;

	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			theScoreManager.AddScore (scoreToGive);
			gameObject.SetActive (false);
		}
	}
}
