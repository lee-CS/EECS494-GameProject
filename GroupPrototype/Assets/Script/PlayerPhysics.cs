using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour {

	public LayerMask collisionMask;
	public LayerMask collisionMask2;
	public LayerMask collisionMask3;
	public LayerMask collisionMask4;

	private BoxCollider collider;
	private Vector3 size;
	private Vector3 center;

	private float skin = .005f;

	Ray ray;
	RaycastHit hit;

	PlayerInput playerInput;

	// Use this for initialization
	void Start () {
		playerInput = GetComponent<PlayerInput> ();
		collider = GetComponent<BoxCollider> ();
		size = collider.size;
		center = collider.center;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Move(Vector2 moveAmount) {
		
		float deltaY = moveAmount.y;
		float deltaX = moveAmount.x;
		
		float Xpos = moveAmount.x;
		float Ypos = moveAmount.y;
		Vector2 p = transform.position;
		
		
		//up and down collision

		for (int i = 0; i < 3; i++) {
			float dir = Mathf.Sign(deltaY);
			float x = (p.x + center.x - size.x/2) + size.x/2 * i;
			float y = p.y + center.y +size.y/2 * dir;
			
			ray = new Ray(new Vector2(x, y), new Vector2(0, dir));
			Debug.DrawRay(ray.origin, ray.direction);
			
			
			if(Physics.Raycast (ray, out hit, Mathf.Abs(deltaY) + skin, collisionMask)) {
				float dist = Vector3.Distance(ray.origin, hit.point);
				
				if(dist > skin) {
					deltaY = dist * dir - skin * dir;
				}
				
				else {
					deltaY = 0;
				}

				break;
			}
			
			
			if(Physics.Raycast (ray, out hit, Mathf.Abs(deltaY) + skin, collisionMask2)) {
				float dist = Vector3.Distance(ray.origin, hit.point);
				
				if(dist > skin) {
					deltaY = dist * dir - skin * dir;
				}
				
				else {
					deltaY = 0;
				}

				break;
			}
			
		}
		
		//left and right collision

		
		if (deltaX != 0) {
			for (int i = 0; i < 3; i++) {
				float dir = Mathf.Sign (deltaX);
				float x = p.x + center.x + size.x / 2 * dir;
				float y = p.y + center.y - size.y / 2 + size.y / 2 * i;
				
				ray = new Ray (new Vector2 (x, y), new Vector2 (dir, 0));
				Debug.DrawRay (ray.origin, ray.direction);
				
				
				if (Physics.Raycast (ray, out hit, Mathf.Abs (deltaX) + skin, collisionMask)) {
					float dist = Vector3.Distance (ray.origin, hit.point);
					


					if (dist > skin) {
						deltaX = dist * dir - skin * dir;
					} else {
						deltaX = 0;
					}
					
					
					break;
				}
				
				if (Physics.Raycast (ray, out hit, Mathf.Abs (deltaX) + skin, collisionMask2)) {
					float dist = Vector3.Distance (ray.origin, hit.point);
		
					
					break;
				}
				

			}
		}

		Vector3 enemyDir = new Vector3 (deltaX, deltaY);
		Vector3 o = new Vector3 (p.x + center.x * Mathf.Sign(deltaX), p.y + center.y * Mathf.Sign(deltaY));
		Debug.DrawRay (o, enemyDir.normalized);
		
		ray = new Ray (o, enemyDir.normalized);

		if (Physics.Raycast (ray, Mathf.Sqrt (deltaX * deltaX + deltaY * deltaY), collisionMask)) {
			deltaX = 0;
			deltaY = 0;
		}

		Vector2 finalTransform = new Vector2 (deltaX, deltaY);
		
		transform.Translate(finalTransform);
	}
}
