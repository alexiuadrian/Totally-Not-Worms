using UnityEngine;
using System.Collections;
using System;

public class Sniper_Move : MonoBehaviour {
	public KeyCode shootKey = KeyCode.T;
	public Transform sprite;
	// Use this for initialization
	Animator anim;
	//Speed and jump vary between characters
	public bool sniper_spawn;
	public float Speed = 1.00f;
	public float Jump = 2.5f;
	public static bool grounded;
	public bool ground;
	public static bool Scout = false;
	public Rigidbody2D rigid;
	public static int health = 30;
	Movement Move = new Movement ();

	Ray2D ray;
	RaycastHit2D hit;

	public GameObject bullet;
	public GameObject bulletSpawn;
	void Start () {
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

			if (Input.GetKeyDown(shootKey))
			{
				Shoot();
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
		hit = Physics2D.Raycast (GameObject.Find("Sniper_Feet").transform.position, Vector2.down);

		if(hit.distance < 0.03){
			grounded = true;
		}
		if(hit.distance > 0.03){
			grounded = false;
		}
	}
	public void Shoot(){
		GameObject SniperBullet = Instantiate (bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation) as GameObject;
		SniperBullet.tag = "Bullet";
		if(Movement.facingRight){
			SniperBullet.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 550);
		}
		if(!Movement.facingRight){
			SniperBullet.GetComponent<Rigidbody2D> ().AddForce (Vector2.left * 550);
		}
		Destroy (SniperBullet, 1.5f);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "ScoutBullet")
		{
			health -= 4;
		}
		if (other.gameObject.tag == "DemomanBullet")
		{
			health -= 6;
		}	
		if (other.gameObject.tag == "HeavyBullet")
		{
			health -= 7;
		}
		if (other.gameObject.tag == "CaptainBullet")
		{
			health -= 6;
		}
		if (other.gameObject.tag == "SoldierBullet")
		{
			health -= 8;
		}	
	}
	
}
