using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	public int player_num;

	public float speed 				= 8;
	public float accel 				= 30;

	public float currentSpeed;
	private float targetSpeed;
	public float currentSpeed2;
	private float targetSpeed2;
	private Vector2 amountToMove;

	public Vector3 spawn_point;
	private Vector3 starting;


	private PlayerPhysics physics;

	public int wallCount			= 0;

	public GameObject wallPrefab;
	private bool buildingWall;
	private GameObject[] curWall = new GameObject[100];

	public ColorType curColor;

	private Color red_color = new Color(1, 0, 0, 1);
	private Color yellow_color = new Color(1, 1, 0, 1);
	private Color green_color = new Color(0, 1, 0, 1);
	private Color blue_color = new Color(0, 0, 1, 1);

	private bool canBuild;

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

		canBuild = true;

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
		if ((verifyPlayer() && Input.GetKeyDown(KeyCode.F)||
		    (!verifyPlayer() && Input.GetKeyDown (KeyCode.Period))) && canBuild) {

			if (wallCount == 3) {
				wallCount--;
				Destroy(curWall[0]);
				curWall[0] = curWall[1];
				curWall[1] = curWall[2];
			}

			GameObject wall = (GameObject)Instantiate(wallPrefab);
			wall.GetComponent<MeshRenderer>().material.color = Util.getColorObject(curColor);
			wall.transform.position = transform.position;
			if(wall.renderer.material.color == red_color)
				wall.GetComponent<wall>().color = "red";
			if(wall.renderer.material.color == yellow_color)
				wall.GetComponent<wall>().color = "yellow";
			if(wall.renderer.material.color == green_color)
				wall.GetComponent<wall>().color = "green";
			if(wall.renderer.material.color == blue_color)
				wall.GetComponent<wall>().color = "blue";
			Color temp = wall.GetComponent<MeshRenderer>().material.color; 
			temp.a = 0f;
			wall.GetComponent<MeshRenderer>().material.color = temp;
			wall.GetComponent<wall>().underConstruction = true;
			Debug.Log("wall");
			buildingWall = true;
			curWall[wallCount] = wall;
			wallCount++;
		}
		/// Continue construction
		if ( (verifyPlayer() && Input.GetKey (KeyCode.F) && buildingWall ) ||
		    (!verifyPlayer() && Input.GetKey (KeyCode.Period) && buildingWall ))
		{
			Color temp = curWall[wallCount-1].renderer.material.color; 
			curWall[wallCount-1].renderer.material.color = temp;	
			if (curWall[wallCount-1].renderer.material.color.a >= 1.0f) {
				Debug.Log("wall completed");
				buildingWall = false;
				audio.Play ();
			}
		}
		/// Cancel construction if you let go while still being built
		if ( (verifyPlayer() && Input.GetKeyUp (KeyCode.F) && buildingWall)){
			wallCount--;
			Destroy (curWall[wallCount]);
			curWall[wallCount] = null;
			buildingWall = false;
		}
		else if ( (!verifyPlayer() && Input.GetKeyUp (KeyCode.Period) && buildingWall)){
			wallCount--;
			Destroy (curWall[wallCount]);
			curWall[wallCount] = null;
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

		if (c.tag == "no") {
			canBuild = false;
		}
	}

	void OnTriggerExit(Collider c) {
		if(c.tag == "no"){
			canBuild = true;
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
