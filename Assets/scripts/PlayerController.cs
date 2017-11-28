using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 1.5f;

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
		var x = Input.GetAxisRaw ("Horizontal") * Time.deltaTime * speed;
		var y = Input.GetAxisRaw ("Vertical") * Time.deltaTime * speed;

		if (y == 0 & x == 0) 
			direction = -1; 		 //No button is pressed
		else if (y > 0 & x == 0)
			direction = 0;	 		 //Only up is pressed
		else if (y > 0 & x > 0){ 
			direction = 1;			 //Right and up is pressed
			transform.rotation = Quaternion.Euler(0f, 0f, 0f);
		}else if (y == 0 & x > 0){ 
			direction = 2;			 //Only right is pressed
			transform.rotation = Quaternion.Euler(0f, 0f, 0f);
		}else if (y < 0 & x > 0){ 
			direction = 3;			 //Right and down is pressed		
			transform.rotation = Quaternion.Euler(0f, 0f, 0f);
		}else if (y < 0 & x == 0) 
			direction = 4;			 //Only down is pressed
		else if (y < 0 & x < 0){ 
			direction = 5;			 //Left and down is pressed
			transform.rotation = Quaternion.Euler(0f, 180f, 0f);
		}else if (y == 0 & x < 0){ 
			direction = 6;			 //Only left is pressed
			transform.rotation = Quaternion.Euler(0f, 180f, 0f);
		}else if (y > 0 & x < 0){ 
			direction = 7;			 //Left and up is pressed
			transform.rotation = Quaternion.Euler(0f, 180f, 0f);
		}
		anim.SetInteger ("moving", direction + 1);
		transform.position = new Vector2 (transform.position.x + x * 10, transform.position.y );


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
	}

	void shoot(){
		GameObject bullet = (GameObject)Instantiate(bulletPrefab, new Vector3(transform.position.x + gunOffset[0].x, transform.position.y + gunOffset[0].y, 0), Quaternion.identity );
		bullet.GetComponent<BulletController>().setDirection(direction);
	}
}