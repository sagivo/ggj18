using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotStd : MonoBehaviour {

	protected float RandomInScreenX(){
		var dist = (this.transform.position - Camera.main.transform.position).z;
		var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,0,dist)).x;

		var w = rightBorder * 2;
		return (Random.value * w) - (w/2);
	}

	protected float RandomInScreenY(){
		var dist = (this.transform.position - Camera.main.transform.position).z;
		var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,dist)).y;

		var h = topBorder * 2;
		return (Random.value * h) - (h/2);
	}
}
