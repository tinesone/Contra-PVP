using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public GameObject owner;
	public int direction = 0;
	public int speed = 1;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		switch(direction){
		case 0:
			transform.position += new Vector3(0, 0.3125f * speed/10, 0);
			break;
		case 1:
			transform.position += new Vector3(0.3125f * speed/10, 0.3125f * speed/10, 0);
			break;
		case 2:
			transform.position += new Vector3(0.3125f * speed/10, 0, 0);
			break;
		case 3:
			transform.position += new Vector3(0.3125f * speed/10, -0.3125f * speed/10, 0);
			break;
		case 4:
			transform.position += new Vector3(0, -0.3125f * speed/10, 0);
			break;
		case 5:
			transform.position += new Vector3(-0.3125f * speed/10, -0.3125f * speed/10, 0);
			break;
		case 6:
			transform.position += new Vector3(-0.3125f * speed/10, 0, 0);
			break;
		case 7:
			transform.position += new Vector3(-0.3125f * speed/10, 0.3125f * speed/10, 0);
			break;
		}
	}

	void OnBecameInvisible () {
		Destroy(gameObject);
	}
}
