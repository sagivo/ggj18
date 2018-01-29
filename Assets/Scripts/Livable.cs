using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Livable : BaseObj {
    public int HP = 100;
    public int Armor = 1;
    public int Speed = 1;
    public int Damadge = 1;

    public delegate void DieEvent(Player killer);
    public event DieEvent OnDie;

    public delegate void HitEvent(int damadge);
    public event HitEvent OnHit;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Hit(int damage, Player hitter) {        
        HP -= damage;
        if (OnHit != null) OnHit(damage);
        if (HP <= 0) Die(hitter);
    }

    void Die(Player killer) {
        // do some stuff
        if (OnDie != null) OnDie(killer);

        Destroy(gameObject,0.2f);
    }
}
