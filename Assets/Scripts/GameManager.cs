using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public int NumberOfPlayers = 4;
    public AudioClip SplashCellSound;

    AudioSource auioSource;

    public Player[] players;
    public Transform[] SpawningPoints;
	// Use this for initialization
	void Start () {
        auioSource = GetComponent<AudioSource>();
        for (int i = 0; i < NumberOfPlayers; i ++) {
            Player p = Instantiate(players[i], SpawningPoints[i]);
            p.PlayerNumber = i + 1;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playSplash() {
        auioSource.clip = SplashCellSound;
        auioSource.Play();
    }
}
