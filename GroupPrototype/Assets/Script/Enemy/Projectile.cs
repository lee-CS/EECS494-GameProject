using UnityEngine;
using System.Collections;



/* A generic projectile. Based off of Enemy script. */
public class Projectile : MonoBehaviour {

	
	//Enemy Stats Vars
	//public GameCamera target;
	public string type;
	public float speed;
	public bool goTowardsCrystal = true;
	//for Camera
	public float max_dist = 6.4f;	
	public bool colorOverriding = false;


	//public GameObject tree;
	


	
	
	//For Movement
	private float currentSpeed;
	private float targetSpeed;
	private Vector2 target;
	public ColorType color;

	enemy_physics physics;


	public float angle;
	float speed_rotate = (2 * Mathf.PI) / 5; //2*PI in degress is 360, so you get 5 seconds to complete a circle
	float radius=20;



	// Sets a new position for the projectile to head towards
	public void goTo(Vector2 t) {
		target = t;
	}







	
	



	void Start () {
		
		physics = GetComponent<enemy_physics>();
		if (!colorOverriding)
			color = Util.randomColor ();

		GetComponent<MeshRenderer>().material.color = Util.getColorObject(color);

		if (goTowardsCrystal) {
			goTo(GameObject.FindGameObjectWithTag("Crystal").transform.position);
		}

	}

	void Update () {

		if (type != "circular") {
						Vector2 amountToMove;
						// Handle movement
						amountToMove.x = Mathf.Cos (Util.getAngleVector (target, transform.position)) * speed;
						amountToMove.y = Mathf.Sin (Util.getAngleVector (target, transform.position)) * speed;                            	
						physics.Move (amountToMove * Time.deltaTime);
				} 

		else {
			angle += speed_rotate*Time.deltaTime; //if you want to switch direction, use -= instead of +=
			radius -= Time.deltaTime;
			Vector2 temp = new Vector2 (0, 0);
			temp.x = Mathf.Cos(angle)*radius;
			temp.y = Mathf.Sin(angle)*radius;
			transform.position = temp;

				
				}
		
	}
	
	void OnTriggerEnter(Collider c) {
		if (c.gameObject.tag == "Crystal") {
			Destroy (gameObject);
			c.gameObject.GetComponent<Health>().takeHit (10);
		}

		if (c.gameObject.tag == "Wall") {
			Destroy (gameObject);
		}
	}

	void OnTriggerStay(Collider c){
		if (color == ColorType.Red && c.gameObject.layer == 11) {
			Destroy (gameObject);
		}
		if (color == ColorType.Blue && c.gameObject.layer == 8) {
			Destroy (gameObject);
		}
		if (color == ColorType.Green && c.gameObject.layer == 9) {
			Destroy (gameObject);
		}
		if (color == ColorType.Yellow && c.gameObject.layer == 10) {
			Destroy (gameObject);
		}
	}

}
