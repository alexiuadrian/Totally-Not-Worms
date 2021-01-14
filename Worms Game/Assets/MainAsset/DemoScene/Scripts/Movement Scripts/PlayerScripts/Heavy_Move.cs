using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Heavy_Move : MonoBehaviour {
	public KeyCode shootKey = KeyCode.T;
	public Transform sprite;
	// Use this for initialization
	Animator anim;
	//Speed and jump vary between characters
	public bool heavy_spawn;
	public float Speed = 0.8f;
	public float Jump = 2.5f;
	public static bool grounded;
	public bool ground;
	public static bool Scout = false;
	public Rigidbody2D rigid;
	Movement Move = new Movement ();

	Ray2D ray;
	RaycastHit2D hit;

	public bool PressedDown;

	public GameObject bullet;
	public GameObject gunPoint;

	public float shotCounter;
	public float loadingCounter;

	void Start ()
	{
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

	bool inputEnabled = false;

	public void Activate()
	{
		inputEnabled = true;
	}

	public void Deactivate()
	{
		inputEnabled = false;
	}

	public void Shooting()
	{
		GameObject heavyBullet = Instantiate(bullet, gunPoint.transform.position, gunPoint.transform.rotation) as GameObject;
		heavyBullet.tag = "HeavyBullet";
		Destroy(heavyBullet, 1.5f);
		if (Movement.facingRight)
		{
			heavyBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
		}
		if (!Movement.facingRight)
		{
			heavyBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 200);
		}
	}

	public void GroundDetection()
	{
		hit = Physics2D.Raycast(GameObject.Find("Heavy_Feet").transform.position, Vector2.down);
		if (hit.distance < 0.03)
		{
			grounded = true;
		}
		if (hit.distance > 0.03)
		{
			grounded = false;
		}
	}
}


