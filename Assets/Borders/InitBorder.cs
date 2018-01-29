using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBorder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var dist = (this.transform.position - Camera.main.transform.position).z;
		var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,dist)).x;
		var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,0,dist)).x;
		var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,dist)).y;
		var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,1,dist)).y;

		var borders = GetComponentsInChildren<Transform> ();
		foreach (var i in borders) {
			switch (i.name) {

			case "rightBorder":
				i.transform.localPosition = new Vector3 (rightBorder ,i.transform.localPosition.y, i.transform.localPosition.z);
				//Debug.Log (i.name);	
				break;	
			case "leftBorder":
				i.transform.localPosition = new Vector3 (leftBorder ,i.transform.localPosition.y, i.transform.localPosition.z);
				break;
			case "topBorder":
				i.transform.localPosition = new Vector3 (i.transform.localPosition.y ,topBorder, i.transform.localPosition.z);
				break;
			case "bottomBorder":
				i.transform.localPosition = new Vector3 (i.transform.localPosition.y ,bottomBorder, i.transform.localPosition.z);
				break;
			}

		}

	}

}
