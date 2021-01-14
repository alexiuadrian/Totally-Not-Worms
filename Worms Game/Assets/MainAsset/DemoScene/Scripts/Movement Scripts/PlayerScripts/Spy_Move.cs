using UnityEngine;
using System.Collections;
using System;

public class Spy_Move : MonoBehaviour {
	public KeyCode shootKey = KeyCode.T;
	public Transform sprite;
	// Use this for initialization
	Animator anim;
	//Speed and jump vary between characters
	public bool spy_spawn;
	public float Speed = 1.07f;
	public float Jump = 2.5f;
	public static bool grounded;
	public bool ground;
	public static bool Scout = false;
	public Rigidbody2D rigid;
	Movement Move = new Movement ();

	bool inputEnabled = false;

	Ray2D ray;
	RaycastHit2D hit;

	public GameObject gunPoint;
	public GameObject bullet;

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
				Shooting();
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		// Destroy(other.gameObject);
		// Debug.Log("Intra");
		if (other.gameObject.tag == "Bullet")
		{
			Destroy(gameObject);
		}
	}

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
		Console.Write("Spy futut in cur!");
	}

	public void GroundDetection(){
		hit = Physics2D.Raycast (GameObject.Find("Spy_Feet").transform.position, Vector2.down);

		if(hit.distance < 0.03){
			grounded = true;
		}
		if(hit.distance > 0.03){
			grounded = false;
		}
	}
	public void Shooting(){
		GameObject spyBullet = Instantiate (bullet, gunPoint.transform.position, gunPoint.transform.rotation) as GameObject;
		spyBullet.tag = "Bullet";
		Destroy (spyBullet, 0.8f);
		if(Movement.facingRight){
			spyBullet.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 200);
		}
		if(!Movement.facingRight){
			spyBullet.GetComponent<Rigidbody2D> ().AddForce (Vector2.left * 200);
		}
	}
}

