using UnityEngine;
using System.Collections;
using System;

public class Soldier_Move : MonoBehaviour {
	public KeyCode shootKey = KeyCode.T;
	public Transform sprite;
	// Use this for initialization
	Animator anim;
	//Speed and jump vary between characters
	public bool soldier_spawn;
	public float Speed = 0.85f;
	public float Jump = 2.5f;
	public static bool grounded;
	public bool ground;

	public static bool Scout = false;
	public Rigidbody2D rigid;
	Movement Move = new Movement ();

	Ray2D ray;
	RaycastHit2D hit;

	public GameObject bullet;
	public GameObject gunPoint;
	public float bulletStrengh;

	void Start () {
		bulletStrengh = 200;
		anim = GetComponent<Animator>();
	}
	void FixedUpdate(){

		GroundDetection ();
		ground = grounded;

	}

	// Update is called once per frame
	void Update () {
		if(inputEnabled)
		{
			anim.SetFloat("Speed", Mathf.Abs(rigid.velocity.x));
			// anim.SetBool("touchingGround", grounded);

			Move.Motion(Speed, Jump, rigid, grounded, Scout, sprite);

			if (Input.GetKey(shootKey))
			{
				bulletStrengh = bulletStrengh + (Time.deltaTime * 200);
			}
			if (Input.GetKeyUp(shootKey))
			{
				Shooting();
			}
		}
	}

	bool inputEnabled = false;

	public void Activate()
	{
		inputEnabled = true;
	}

	public void Deactivate()
	{
		inputEnabled = false;
	}

	public void Penalty()
	{
		Console.Write("Scout futut in cur!");
	}

	public void GroundDetection(){
		hit = Physics2D.Raycast (GameObject.Find("Soldier_Feet").transform.position, Vector2.down);
		if(hit.distance < 0.03){
			grounded = true;
		}
		if(hit.distance > 0.03){
			grounded = false;
		}
	}
	public void Shooting(){
		if(bulletStrengh > 500){
			bulletStrengh = 500;
		}
		GameObject soldierBullet = Instantiate (bullet, gunPoint.transform.position, gunPoint.transform.rotation) as GameObject;
		Destroy (soldierBullet, 1.2f);
		if(Movement.facingRight){
			soldierBullet.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * bulletStrengh);
		}
		if(!Movement.facingRight){
			soldierBullet.GetComponent<Rigidbody2D> ().AddForce (Vector2.left * bulletStrengh);
		}
		bulletStrengh = 200;
	}

	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Grass")
		{
			Debug.Log("dasfdas");
			Destroy(other.gameObject);
		}
	}

}


