using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public GameObject owner;
	public int direction = 2;
	public int speed = 1;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		switch(direction){
			case 0:
				break;
			case 1:
				break;
			case 2:
				transform.position += Vector3.right * speed * Time.deltaTime;
				break;
			case 3:
				break;
			case 4:
				break;
			case 5:
				break;
			case 6:
				break;
			case 7:
					break;
		}
	}

	void OnBecameInvisible () {
		Destroy(gameObject);
	}
}
