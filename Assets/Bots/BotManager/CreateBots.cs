using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBots : BotStd {
	public GameObject bot;
	public int createBotsAtStart = 5;

	public GameObject[] botPref;

	// Use this for initialization
	void Start () {
		var bots = new List<int>();
        var numPlayers = FindObjectOfType<GameManager>().NumberOfPlayers;

        for (var i = 1; i <= numPlayers; i++) {
			//Instantiate(bot, new Vector3(RandomInScreenX(),RandomInScreenY(),0), Quaternion.identity);
			bots.Add(i);
		}
		StartCoroutine(CreateBot(bots));
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void AddBot(List<int> PlayerNumber){
		StartCoroutine(CreateBot(PlayerNumber));
	}

	IEnumerator CreateBot(List<int> playerNumbers){

		foreach (var playerNumber in playerNumbers) {

			Vector3 spawnPoint;// = new Vector3(RandomInScreenX(),RandomInScreenY(),0);

			Collider[] hitColliders;// = Physics.OverlapSphere(spawnPoint, 0.1f);
			do {
				spawnPoint = new Vector3(RandomInScreenX(),RandomInScreenY(),0);
				hitColliders = Physics.OverlapSphere(spawnPoint, 0.2f);//1 is purely chosen arbitrarly
				if(hitColliders.Length <= 0){
					break;
				} //You have someone with a collider here
				yield return null;
			} while(true);

            var b = Instantiate(bot, spawnPoint, Quaternion.identity);
            b.GetComponent<Cell>().PlayerNumber = playerNumber;


			yield return null;
		}

		playerNumbers = null;

	}

}
