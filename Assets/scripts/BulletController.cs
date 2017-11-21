using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public GameObject owner;
	public int speed = 1;

	protected int direction = 0;

	// Update is called once per frame
	void Update () {
		switch(direction){
		case 0:
			transform.position += new Vector3(0, 0.3125f * speed/10, 0); 	//Go up
			break;
		case 1:
			transform.position += new Vector3(0.3125f * speed/10, 0.3125f * speed/10, 0);	 //Go right and up
			break;
		case 2:
			transform.position += new Vector3(0.3125f * speed/10, 0, 0);	 //Go right
			break;
		case 3:
			transform.position += new Vector3(0.3125f * speed/10, -0.3125f * speed/10, 0);	 //Go right and down
			break;
		case 4:
			break;
		case 5:
			transform.position += new Vector3(-0.3125f * speed/10, -0.3125f * speed/10, 0); 	//Go left and down
			break;
		case 6:
			transform.position += new Vector3(-0.3125f * speed/10, 0, 0);	 //Go left
			break;
		case 7:
			transform.position += new Vector3(-0.3125f * speed/10, 0.3125f * speed/10, 0);	 //Go left and Up
			break;
		}
	}

	void OnBecameInvisible () {
		Destroy(gameObject);
	}
		
	public void setDirection (int d){
		direction = d;
	}
}
