using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EndGameOnTime : MonoBehaviour {
	public Text countDown;
	public float gameTime;

	public GameObject plane;

	public GameObject[] scores;

	private AudioSource audio;

	void Start () {
		plane.SetActive (false);
		audio = GetComponent<AudioSource> ();
	}
	
	private bool endgame = false;
	void Update () {
		gameTime -= Time.fixedDeltaTime;
		countDown.text =  Math.Round(gameTime).ToString();

		if (gameTime < 0 && endgame==false) {
			endgame = true;
			var cells = GameObject.FindGameObjectsWithTag ("bot");
			var scoresNum = new int []{ 0, 0, 0, 0 };
			foreach (var i in cells) {
				scoresNum[i.GetComponent<Cell>().PlayerNumber-1]++;
			}
			for (var j=0;j<4;j++) {
				scores [j].GetComponent<Text> ().text = "Player " +j +" Score: "+ scoresNum [j].ToString();
			}
			plane.SetActive (true);

			audio.volume -= Time.fixedDeltaTime*0.1f;

		}
	}

	public void RestartSceen(){
		Application.LoadLevel(0);
	}

}
