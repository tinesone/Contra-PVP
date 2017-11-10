using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrl : MonoBehaviour {

	public float velocity = 6.5f;
	public float jump = 3.0f;

	// Use this for initialization
	void Start () {
		Debug.Log ("started ctrl script");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			transform.rotation = Quaternion.Euler(0, -180, 0);
			transform.position += Vector3.left * velocity * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
			transform.position += Vector3.right * velocity * Time.deltaTime;
		}
	}
}