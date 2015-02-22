using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	public int player_num;

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

	public GameObject wallPrefab;
	private bool buildingWall;
	private GameObject curWall;

	public ColorType curColor;

	// Use this for initialization
	void Start () {
		if (player_num == 1)
			curColor = ColorType.Blue;
		if (player_num == 2)
			curColor = ColorType.Red;
		GetComponent<MeshRenderer>().material.color = Util.getColorObject(curColor);

		physics = GetComponent<PlayerPhysics>();

		Vector3 temp = new Vector3 (0, 0, 0);
		starting = new Vector3(0,0,0);

		spawn_point = temp;

	}
	
	// Update is called once per frame
	void Update () {

		if (!buildingWall) {

			if (player_num == 1) {
				targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
				targetSpeed2 = Input.GetAxisRaw("Vertical") * speed;
			}

			if (player_num == 2) {
				targetSpeed = Input.GetAxisRaw("Horizontal2") * speed;
				targetSpeed2 = Input.GetAxisRaw("Vertical2") * speed;
			}
			
			
			currentSpeed = distance(currentSpeed, targetSpeed, accel);
			currentSpeed2 = distance(currentSpeed2, targetSpeed2, accel);

			amountToMove.x = currentSpeed;
			amountToMove.y = currentSpeed2;

			physics.Move(amountToMove*Time.deltaTime);
		}

		///CONSTRUCTION CONTROLS

		/// Begin construction
		if (verifyPlayer() && Input.GetKeyDown(KeyCode.F)||
		    (!verifyPlayer() && Input.GetKeyDown (KeyCode.Period))) {
			GameObject wall = (GameObject)Instantiate(wallPrefab);
			wall.GetComponent<MeshRenderer>().material.color = Util.getColorObject(curColor);
			wall.transform.position = transform.position;
			Color temp = wall.GetComponent<MeshRenderer>().material.color; 
			temp.a = 0f;
			wall.GetComponent<MeshRenderer>().material.color = temp;
			wall.GetComponent<wall>().underConstruction = true;
			Debug.Log("wall");
			buildingWall = true;
			curWall = wall;
		}
		/// Continue construction
		if ( (verifyPlayer() && Input.GetKey (KeyCode.F) && buildingWall ) ||
		    (!verifyPlayer() && Input.GetKey (KeyCode.Period) && buildingWall ))
		{
			Color temp = curWall.renderer.material.color; 
			curWall.renderer.material.color = temp;	
			if (curWall.renderer.material.color.a >= 1.0f) {
				Debug.Log("wall completed");
				buildingWall = false;
				curWall = null;
			}
		}
		/// Cancel construction if you let go while still being built
		if ( (verifyPlayer() && Input.GetKeyUp (KeyCode.F) && buildingWall)){
			Destroy (curWall);
			buildingWall = false;
		}
		else if ( (!verifyPlayer() && Input.GetKeyUp (KeyCode.Period) && buildingWall)){
			Destroy (curWall);
			buildingWall = false;
		}


		if (verifyPlayer() && Input.GetKeyDown(KeyCode.G) && !buildingWall) {
			if (curColor == ColorType.Blue) {
				curColor = ColorType.Green;
			}
			else {
				curColor = ColorType.Blue;
			}
			GetComponent<MeshRenderer>().material.color = Util.getColorObject(curColor);

		}
		if (!verifyPlayer() && Input.GetKeyDown(KeyCode.Slash) && !buildingWall) {
			if (curColor == ColorType.Red) {
				curColor = ColorType.Yellow;
			}
			else {
				curColor = ColorType.Red;
			}
			GetComponent<MeshRenderer>().material.color = Util.getColorObject(curColor);
		}

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

	private bool verifyPlayer() {
		if (player_num == 1)
			return true;
		return false;

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
