using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : Livable
{
    public int PlayerNumber;
    public Color[] colors = new Color[4];
	public GameObject[] prefubs;
    public int SplitNumber = 3;

    void Start()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        if (PlayerNumber > 0) gm.players[PlayerNumber - 1].cells.Add(this);

        OnDie += (killer) => {
            // play sound
            gm.playSplash();
            // spawn 2 more if other player killed the cell
            if (killer.PlayerNumber != PlayerNumber)
            {
                var bc = GameObject.Find("BotManager").GetComponent<CreateBots>();
                List<int> l = new List<int>();
                for (var i = 0; i < SplitNumber; i++)
                {
                    l.Add(killer.PlayerNumber);
                }

                bc.AddBot(l);
            }
        };

        Instantiate(prefubs[PlayerNumber - 1], transform);
        GetComponent<SpriteRenderer>().color = colors[PlayerNumber - 1];
    }


    void Update()
    {

    }
}
