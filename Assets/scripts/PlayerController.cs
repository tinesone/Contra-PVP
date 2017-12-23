using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 6.5f;
	public int gravity = 6;
	public GameObject bulletPrefab;
	public List<Vector2> gunOffset = new List<Vector2>(8);

	protected bool grounded;
	protected bool jumping = false;
	protected Animator anim;
	protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
	protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D> (16);
	protected int direction = -1;

	void OnEnable()
	{
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		Vector2 input = new Vector2(Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		if (input.y == 0 & input.x == 0) {
			direction = -1;				//No button is pressed
		} else if (input.y > 0 & input.x == 0) {
			direction = 0;				//Only up is pressed
		} else if (input.y > 0 & input.x > 0) {
			direction = 1;				//Right and up is pressed
		} else if (input.y == 0 & input.x > 0) {
			direction = 2;				//Only right is pressed
		} else if (input.y < 0 & input.x > 0) {
			direction = 3;				//Right and down is pressed
		} else if (input.y < 0 & input.x == 0) {
			direction = 4;				//Only down is pressed
		} else if (input.y < 0 & input.x < 0) {
			direction = 5;				//Left and down is pressed
		} else if (input.y == 0 & input.x < 0) {
			direction = 6;				//Only left is pressed
		} else if (input.y > 0 & input.x < 0) {
			direction = 7;				//Left and up is pressed
		}
		transform.position += new Vector3(input.x*0.3125f * speed/10, 0, 0);

		if(Input.GetKeyDown("space"))
			shoot();

		//==========GRAVITY==========
		for(int i = 0; i < gravity; i++) {
			bool grounded = false;
			float x = transform.position.x;
			float y = transform.position.y;
			Vector2 floor = new Vector2(x-x%1+0.5f, y - 1.03125f);  // Snap to grid formula: x-x%gridWidth+gridOffset
			foreach (Transform child in transform.parent){
				if((Vector2)child.position == floor){
					grounded = true;
					break;
				}
			}
			if(!grounded) {
				float newX = transform.position.x;
				float newY = ((float)transform.position.y - 0.03125f)-((float)transform.position.y - 0.03125f)%0.03125f;
				transform.position = new Vector2(newX, newY);
			}
		}
		//==========GRAVITY==========
		//print(direction);
	}

	void shoot(){
		GameObject bullet = (GameObject)Instantiate(bulletPrefab, new Vector3(transform.position.x + gunOffset[0].x, transform.position.y + gunOffset[0].y, 0), Quaternion.identity );
		bullet.GetComponent<BulletController>().setDirection(direction);
	}
}
