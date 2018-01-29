using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotControl : BotStd {
	private float timeMove;
	private Vector3 moveVector;

	private Camera cam;
	private Rigidbody2D rb2;

	void Start () {
		GetNewVectorMove ();
		cam = GameObject.FindWithTag ("MainCamera").GetComponent<Camera>();
		rb2 = GetComponent<Rigidbody2D> ();
	}

	void Update () {

		timeMove -= Time.deltaTime;
		if (timeMove > 0) {
			transform.localPosition += moveVector*Time.deltaTime;
		} else {
			GetNewVectorMove ();
		}

		CheckIfMobInScreen ();

	}

	private void CheckIfMobInScreen(){
		
		Vector3 screenPoint = cam.WorldToViewportPoint(transform.position);

		if (screenPoint.y < 0 || screenPoint.y > 1 || screenPoint.x < 0 || screenPoint.x > 1) {

			LayerMask mask = LayerMask.GetMask("Border"); 
			RaycastHit hit;
			if ( Physics.Raycast (transform.position, -moveVector,out hit,1000,mask.value, QueryTriggerInteraction.Collide )) {
				transform.position = hit.point;
			}

		}

	}

	private void GetNewVectorMove(){
		timeMove = Random.value * 10;
		moveVector = (new Vector3 (RandomInScreenX (), RandomInScreenY (), 0) - transform.position).normalized;
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
        //if (coll.gameObject.tag == "bot")
        //    coll.gameObject.SendMessage("ApplyDamage", 10);
        Debug.Log("boom");
	
		moveVector = coll.contacts [0].normal;

    }
		
}
