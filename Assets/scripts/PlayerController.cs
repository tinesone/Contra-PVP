using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float velocity = 6.5f;

	public GameObject bulletPrefab;
	public List<Vector2> gunOffset = new List<Vector2>(8);

	protected bool grounded;
	protected Rigidbody2D rigid;
	protected Animator anim;
	protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
	protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D> (16);
	protected int direction = -1;

	void OnEnable()
	{
		rigid = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * velocity;
		var y = Input.GetAxis ("Vertical") * Time.deltaTime * velocity;

		if (y == 0 & x == 0) {
			direction = -1; 	//No button is pressed
		} else if (y > 0 & x == 0) {
			direction = 0;	 //Only up is pressed
		} else if (y > 0 & x > 0) {
			direction = 1;			//Right and up is pressed
		} else if (y == 0 & x > 0) { 
			direction = 2;			//Only right is pressed
		} else if (y < 0 & x > 0) {
			direction = 3;			//Right and down is pressed		
		} else if (y < 0 & x == 0) {
			direction = 4;			//Only down is pressed
		} else if (y < 0 & x < 0) {
			direction = 5;			//Left and down is pressed
		} else if (y == 0 & x < 0) {
			direction = 6;	 //Only left is pressed
		} else if (y > 0 & x < 0) {
			direction = 7;			//Left and up is pressed
		}
		transform.position += new Vector3(x/2, 0, 0);

		if(Input.GetKeyDown("space"))
			shoot();
		grounded = false;
		int count = rigid.Cast (Vector2.down, hitBuffer, 0.03125f);
		hitBufferList.Clear ();
		for (int i = 0; i < count; i++) {
			hitBufferList.Add (hitBuffer [i]);
		}
		for (int i = 0; i < hitBufferList.Count; i++) {
			grounded = true;
			transform.position = new Vector3 (transform.position.x, transform.position.y - hitBufferList[i].distance, 0);
		}
		print(direction);
	}

	void shoot(){
		GameObject bullet = (GameObject)Instantiate(bulletPrefab, new Vector3(transform.position.x + gunOffset[0].x, transform.position.y + gunOffset[0].y, 0), Quaternion.identity );
		bullet.GetComponent<BulletController>().setDirection(direction);
	}
}