using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	public float speed = 8;
	public float accel = 30;


	public float currentSpeed;
	private float targetSpeed;
	public float currentSpeed2;
	private float targetSpeed2;
	private Vector2 amountToMove;

	public Vector3 spawn_point;
	private Vector3 starting;


	private PlayerPhysics physics;


	// Use this for initialization
	void Start () {
		physics = GetComponent<PlayerPhysics>();

		Vector3 temp = new Vector3 (0, 0, 0);
		starting = new Vector3(0,0,0);

		spawn_point = temp;

	}
	
	// Update is called once per frame
	void Update () {
		targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
		currentSpeed = distance(currentSpeed, targetSpeed, accel);
		targetSpeed2 = Input.GetAxisRaw("Vertical") * speed;
		currentSpeed2 = distance(currentSpeed2, targetSpeed2, accel);

		amountToMove.x = currentSpeed;
		amountToMove.y = currentSpeed2;

		physics.Move(amountToMove*Time.deltaTime);	
	}

	void OnTriggerEnter(Collider c) {
		
		if (c.tag == "respawn") {
			spawn_point.x = c.transform.position.x;
			spawn_point.y = c.transform.position.y;
			spawn_point.z = c.transform.position.z;

		}

		if (c.tag == "enemy") {
			transform.position = spawn_point;

			
		}

		if (c.tag == "end") {
			transform.position = starting;
			
			
		}
		
	}


	//my functions

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
}
