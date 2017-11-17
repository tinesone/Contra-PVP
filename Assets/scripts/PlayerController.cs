using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public int jump = 6;
	public float velocity = 6.5f;
	public GameObject bulletPrefab;
	public Vector2 gunOffset;

	public int jump = 6;
	public string direction = "idle";
	protected bool jumpEnable = false;
	protected bool grounded;
	protected Rigidbody2D rigid;
	protected Animator anim;
	protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
	protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D> (16);

	void OnEnable()
	{
		rigid = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * velocity;
		var y = Input.GetAxis("Vertical") * Time.deltaTime * velocity;

		if (y == 0 & x == 0) {
			direction = "idle";
			//No button is pressed
		} else if (y > 0f & x > 0f) {
			direction = "RightUp";
			//Left and up is pressed
		} else if (y < 0f & x > 0f) {
			direction = "RightDown";
			//Left and down is pressed
		} else if (y > 0f & x < 0f) {
			direction = "leftUp";
			//Right and up is pressed
		} else if (y < 0f & x < 0f) {
			direction = "leftDown";
			//Right and down is pressed
		} else if (y == 0f & x < 0f) {
			direction = "left";
			//Only right is pressed
		} else if (y == 0f & x > 0f) {
			direction = "right";
			//Only left is pressed
		} else if (y > 0f & x == 0f) {
			direction = "up";
			//Only up is pressed
		} else if  (y < 0f & x == 0f){
			direction = "down";
			//Only down is pressed
		}
		if(Input.GetKeyDown("space")){
		}
			shoot();
		if (Input.GetKey (KeyCode.W) && grounded == true) {
			rigid.AddForce (Vector3.up * (jump * 10));
			jumpEnable = false;
			anim.SetInteger("moving", 0);
		} else {
		}
		grounded = false;
		int count = rigid.Cast (Vector2.down, hitBuffer, 0);
		hitBufferList.Clear ();
		for (int i = 0; i < count; i++) {
		}
			hitBufferList.Add (hitBuffer [i]);
		for (int i = 0; i < hitBufferList.Count; i++) {
			Debug.Log (hitBufferList [i].distance == 0);
			if(hitBufferList [i].distance == 0) grounded = true;
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