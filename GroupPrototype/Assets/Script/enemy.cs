using UnityEngine;
using System.Collections;

public class enemy : Entity {


	//Enemy Stats Vars
	//public GameCamera target;
	public string type;
	public float gravity = 0;
	public float speed = 4;
	public float accel = 1000;
	public float jumpHeight = 12;
	public float dir;
	public float attackRange;


	private float jump_val,speed_val;

	//public GameObject tree;

	//for Camera
	public float max_dist = 6.4f;


	//For Movement
	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;


//	//For Attack Anim
//	public float attk_time, attk_delay;
//	public float attk_motion, motion_delay;
//	private bool attking;



	enemy_physics physics;
	
	public Transform ProjectileFireLocation;


	//sounds
	public AudioSource sound_dead;


	// Use this for initialization
	void Start () {
		speed_val = speed;
		jump_val = jumpHeight;

		physics = GetComponent<enemy_physics>();

		//attk_time = attk_delay - motion_delay;

		//dir = -1;


		//tree = GameObject.FindGameObjectsWithTag ("LIFE");
	}
	
	// Update is called once per frame
	void Update () {

		//stillInFrame ();

		//HP Check
		if (GetComponent<Entity> ().health <= 0) {
			var target = GameObject.Find("Main Camera");
			//var sSources = target.GetComponents<AudioSource>();
			//sSources[1].Play();

			if(gameObject.name != "mothership(Clone)")
				Destroy (gameObject);


		}



//		if (type == "boss") {
//			var target = GameObject.Find ("Ryu(Clone)");
//			if (target.transform.position.x < transform.position.x) {
//					dir = -1;
//			} else {
//					dir = 1;
//			}
//		}


		targetSpeed = dir * speed_val;
		currentSpeed = distance(currentSpeed, targetSpeed, accel);

		if(type == "LeftRight")
			amountToMove.x = currentSpeed;

		if(type == "UpDown")
			amountToMove.y = currentSpeed;



		//for attacking not using it right now
//		if (attk_motion > 0) {
//			amountToMove.x = 0;
//		}
//		attk_time -= Time.deltaTime;




		physics.Move(amountToMove*Time.deltaTime);

	}
	
	void OnTriggerEnter(Collider c) {


		if (c.tag == "projectile") {
			GetComponent<Entity>().TakeDamage(1);
			Destroy(c.gameObject);
			
		}

		else if(c.tag == "arrow") {
			GetComponent<Entity>().TakeDamage(3);
			Destroy(c.gameObject);
		}

		else if(c.tag == "javelin") {
			GetComponent<Entity>().TakeDamage(5);
		}

		else if (c.tag == "melee") {
			GetComponent<Entity>().TakeDamage(10);
			//Destroy(c.gameObject);
			
		}

		if (c.tag == "Crystal") {
			//c.GetComponent<life>().HP -= 1;
			Destroy(gameObject);
			
		}

		if (c.tag == "Player") {
			GetComponent<Entity>().TakeDamage(10);
			
		}

	}

	private float distance(float n, float target, float acc) {
		//anim.SetFloat("speed", Mathf.Abs (target));
		
		if (n == target)
			return n;
		else {
			float dir = Mathf.Sign (target - n);
			
			n += acc * Time.deltaTime * dir;
			return (dir == Mathf.Sign (target - n)) ? n : target;
		}
	}




	//If we want to do something like if enemies will do something once they are in range of something (Player or Crystal or Walls)
	private bool inRange(){
		Transform player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		if (Mathf.Abs (transform.position.x - player.position.x) <= attackRange)
			return true;
		return false;
	}


	//UNUSED CODE

	//We can make enemies fire projectiles if we want to
	//	private void FireProjectile() {
	//		var direction = -Vector2.right;
	//		Vector2 temp = new Vector2 (0, 0);
	//		
	//		var projectile = (Projectiles)Instantiate (Projectile, ProjectileFireLocation.position, ProjectileFireLocation.rotation);
	//		projectile.Initialize (gameObject, direction, temp);
	//	}


	//We can make enemies disappear if they get too far away from the player, or we can even make it so that it stays on Screen.
//	private void stillInFrame(){
//		Transform player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
//		float dist = Mathf.Abs (player.position.x - transform.position.x);
//		
//		if (dist > max_dist) {
//			//			print ("DESTROY");
//			Destroy(gameObject);
//		}
//	}
}
