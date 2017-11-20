using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float velocity = 6.5f;
	public GameObject bulletPrefab;
	public Vector2 gunOffset;

	public int jump = 6;
	bool jumpEnable = false;
	public string direction = "idle";

	public Rigidbody2D rigid;

	public Animator anim;


	void Start () {}

	void Update () {
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * velocity;
		var y = Input.GetAxis("Vertical") * Time.deltaTime * velocity;

		if (y == 0 & x == 0) {
			direction = "idle";
			//No button is pressed
		} else if (y > 0f & x > 0f) {
			direction = "leftUp";
			//Left and up is pressed
		} else if (y < 0f & x > 0f) {
			direction = "leftDown";
			//Left and down is pressed
		} else if (y > 0f & x < 0f) {
			direction = "rightUp";
			//Right and up is pressed
		} else if (y < 0f & x < 0f) {
			direction = "rightDown";
			//Right and down is pressed
		} else if (y == 0f & x < 0f) {
			direction = "right";
			//Only right is pressed
		} else if (y == 0f & x > 0f) {
			direction = "left";
			//Only left is pressed
		} else if (y > 0f & x == 0f) {
			direction = "up";
			//Only up is pressed
		} else if  (y < 0f & x == 0f){
			direction = "down";
			//Only down is pressed
		}

		print(direction);
	}

	void shoot(){
		GameObject bullet = (GameObject)Instantiate(bulletPrefab, new Vector3(transform.position.x + gunOffset.x, transform.position.y + gunOffset.y, 0), Quaternion.identity );
		bullet.GetComponent<BulletController>().direction = 2;
	}
	void OnCollisionEnter2D(Collision2D col){
		jumpEnable = true;
	}
}