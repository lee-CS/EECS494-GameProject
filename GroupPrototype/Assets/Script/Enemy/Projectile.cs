using UnityEngine;
using System.Collections;



/* A generic projectile. Based off of Enemy script. */
public class Projectile : MonoBehaviour {

	
	//Enemy Stats Vars
	//public GameCamera target;
	public float speed;
	public bool goTowardsCrystal = true;
	//for Camera
	public float max_dist = 6.4f;	

	//public GameObject tree;
	


	
	
	//For Movement
	private float currentSpeed;
	private float targetSpeed;
	private Vector2 target;
	private ColorType color;

	enemy_physics physics;






	// Sets a new position for the projectile to head towards
	public void goTo(Vector2 t) {
		target = t;
	}







	
	



	void Start () {
		
		physics = GetComponent<enemy_physics>();
		color = Util.randomColor ();
		GetComponent<MeshRenderer>().material.color = Util.getColorObject(color);

		if (goTowardsCrystal) {
			goTo(GameObject.FindGameObjectWithTag("Crystal").transform.position);
		}

	}

	void Update () {
		Vector2 amountToMove;

		
		
		// Handle movement
		amountToMove.x = Mathf.Cos (Util.getAngleVector(target, transform.position)) * speed;
		amountToMove.y = Mathf.Sin (Util.getAngleVector(target, transform.position)) * speed;                            	
		

		
		physics.Move(amountToMove*Time.deltaTime);
		
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






	

}
