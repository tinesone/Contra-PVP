using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float velocity = 6.5f;
	public float jump = 3.0f;
	public GameObject bulletPrefab;
	public Vector2 gunOffset;

	// Use this for initialization
	void Start () {}

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
		if(Input.GetKeyDown("space")){
			shoot();
			print ("piew piew");
			print(transform.position.x);
			print(transform.position.x + gunOffset.x);
		}
	}

	void shoot(){
		Instantiate(bulletPrefab, new Vector3(transform.position.x + gunOffset.x, transform.position.y + gunOffset.y, 0), this.transform.rotation );
	}
}
