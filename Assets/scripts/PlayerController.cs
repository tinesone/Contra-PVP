using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float velocity = 6.5f;
	public GameObject bulletPrefab;
	public Vector2 gunOffset;

	public int jump = 6;
	bool jumpEnable = false;

	public Rigidbody2D rigid;

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
		}
		if (Input.GetKey (KeyCode.W) && jumpEnable == true) {
			rigid.AddForce (Vector3.up * (jump * 10));
			jumpEnable = false;
		}
			
	}

	void shoot(){
		GameObject bullet = (GameObject)Instantiate(bulletPrefab, new Vector3(transform.position.x + gunOffset.x, transform.position.y + gunOffset.y, 0), Quaternion.identity );
		bullet.GetComponent<BulletController>().direction = 2;
	}
	void OnCollisionEnter2D(Collision2D col){
		jumpEnable = true;
	}
}
