using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PowerUpManager : BotStd {

	public GameObject[] powerUp;
	private float resTime;
	public float resTimeMax=5;
	public int maxPowerupsOnScreen=4;

	void Start () {
		resTime = resTimeMax;
	}

	void Update () {

		resTime -= Time.fixedDeltaTime;
		if (resTime < 0) {
			
			if ( GameObject.FindGameObjectsWithTag ("PowerUp").Length < maxPowerupsOnScreen) {
				var tmpRan = (int)(UnityEngine.Random.value * powerUp.Length);
				if (tmpRan == powerUp.Length)
					tmpRan = 0;
				StartCoroutine( CreatePowerUp (tmpRan));
			}
			resTime = resTimeMax;
		}

	}

	IEnumerator CreatePowerUp(int i){

		Vector3 spawnPoint = new Vector3(RandomInScreenX(),RandomInScreenY(),0);

		var hitColliders = Physics.OverlapSphere(spawnPoint, 0.1f);
		do {
			hitColliders = Physics.OverlapSphere(spawnPoint, 0.1f);//1 is purely chosen arbitrarly
			if(hitColliders.Length <= 0){
				break;
			} //You have someone with a collider here
			yield return null;
		} while(true);

		var tmp = Instantiate (powerUp [i], spawnPoint, Quaternion.identity);
		Debug.Log ("PUM");
	}

}
