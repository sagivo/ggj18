using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : Livable {
    public int TurnSpeed = 100;
    public Bullet Bullet;
    public Transform BulletSpawn;
    public float ROF = 4;
    float nextFireTime;
    public int PlayerNumber;
    Slider slider;

	private Camera cam;

	void Start () {
        slider = GetComponentInChildren<Slider>();
		cam = GameObject.FindWithTag ("MainCamera").GetComponent<Camera>();
        HP = 100;

        slider.value = HP;
            
        OnHit += (damadge) => {
            slider.value = HP;
        };
	}
	
	void Update () {
        //Move();
		Move2();
		CheckIfMobInScreen ();
	}

	private void CheckIfMobInScreen(){

		Vector3 screenPoint = cam.WorldToViewportPoint(transform.position);

		if (screenPoint.y < 0 || screenPoint.y > 1 || screenPoint.x < 0 || screenPoint.x > 1) {

			LayerMask mask = LayerMask.GetMask("Border"); 
			RaycastHit hit;
			if ( Physics.Raycast (transform.position, -transform.up,out hit,1000,mask.value, QueryTriggerInteraction.Collide )) {
				transform.position = hit.point;
			}

		}

	}

    void Move2()
    {
        //Debug.Log (PlayerNumber);
        switch (PlayerNumber)
        {
            case 1:
                if (-Input.GetAxis("MoveForward1") > 0)
                {
                    transform.Translate(0, Speed * Time.deltaTime, 0);
                }

                transform.Rotate(-Vector3.forward * Input.GetAxis("MoveSide1") * TurnSpeed * Time.deltaTime);
                if (Input.GetButtonDown("JFire1") && nextFireTime <= Time.time)
                {
                    Bullet bullet = Instantiate(Bullet, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
                    bullet.shooter = this;
                    bullet.Damadge = Damadge;

                    nextFireTime = Time.time + ROF;
                }
                break;
            case 2:
                if (-Input.GetAxis("MoveForward2") > 0)
                {
                    transform.Translate(0, Speed * Time.deltaTime, 0);
                }
                transform.Rotate(-Vector3.forward * Input.GetAxis("MoveSide2") * TurnSpeed * Time.deltaTime);
                if (Input.GetButtonDown("JFire2") && nextFireTime <= Time.time)
                {
                    var bullet = Instantiate(Bullet, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
                    bullet.GetComponent<Bullet>().shooter = this;

                    nextFireTime = Time.time + ROF;
                }
                break;
            case 3:
                if (-Input.GetAxis("MoveForward3") > 0)
                {
                    transform.Translate(0, Speed * Time.deltaTime, 0);
                }
                transform.Rotate(-Vector3.forward * Input.GetAxis("MoveSide3") * TurnSpeed * Time.deltaTime);
                if (Input.GetButtonDown("JFire3") && nextFireTime <= Time.time)
                {
                    var bullet = Instantiate(Bullet, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
                    bullet.GetComponent<Bullet>().shooter = this;

                    nextFireTime = Time.time + ROF;
                }
                break;
            case 4:
                if (-Input.GetAxis("MoveForward4") > 0)
                {
                    transform.Translate(0, Speed * Time.deltaTime, 0);
                }
                transform.Rotate(-Vector3.forward * Input.GetAxis("MoveSide4") * TurnSpeed * Time.deltaTime);
                if (Input.GetButtonDown("JFire4") && nextFireTime <= Time.time)
                {
                    var bullet = Instantiate(Bullet, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
                    bullet.GetComponent<Bullet>().shooter = this;

                    nextFireTime = Time.time + ROF;
                }
                Move();
                break;
        }
    }

    void Move() {
		if (Input.GetKey("up")) {
            transform.Translate(0, Speed * Time.deltaTime, 0);
        }
        if (Input.GetKey("right")) {
            transform.Rotate(-Vector3.forward * TurnSpeed * Time.deltaTime);
        }

        if (Input.GetKey("left")) {
            transform.Rotate(Vector3.forward * TurnSpeed * Time.deltaTime);
        }
        if (Input.GetButtonDown("Fire1") && nextFireTime <= Time.time) {
            var bullet = Instantiate(Bullet, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
            bullet.GetComponent<Bullet>().shooter = this;

            nextFireTime = Time.time + ROF;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.GetComponent<Player>() || other.gameObject.GetComponent<Cell>()) return; // dont do anything with other player
        //Livable l = other.gameObject.GetComponent<Livable>();
        //if (l) {
        //    l.Hit(Damadge, this);
        //    Hit(l.Damadge, this);
        //}
        var powerup = other.gameObject.GetComponent<PowerUp>();
        if (powerup)
        {
            this.Damadge = powerup.Damage;
            this.Speed = powerup.Speed;
            this.Armor = powerup.Armor;
            this.ROF = powerup.ROF;
            Destroy(other.gameObject);

        }

    }
}
