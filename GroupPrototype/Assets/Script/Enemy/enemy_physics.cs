using UnityEngine;
using System.Collections;

public class enemy_physics : MonoBehaviour {
	
	Animator anim;
	
	public LayerMask blueCollision;
	public LayerMask redCollision;
	public LayerMask yellowCollision;
	public LayerMask greenCollision;
	public LayerMask empty_layer;

	
	private BoxCollider collider;
	private Vector3 size;
	private Vector3 center;
	
	private float skin = .005f;
	
	[HideInInspector]
	public bool grounded;
	public bool jumped;

	Ray ray;
	RaycastHit hit;

	float jumpTime, jumpDelay = .5f;

	Projectile _Self;



	
	void Start() {
		_Self = GetComponent<Projectile> ();
		collider = GetComponent<BoxCollider> ();
		size = collider.size;
		center = collider.center;
		anim = GetComponent<Animator> ();
		
	}
	
	public void Move(Vector2 moveAmount) {
		
		float deltaY = moveAmount.y;
		float deltaX = moveAmount.x;
		
		float Xpos = moveAmount.x;
		float Ypos = moveAmount.y;
		Vector2 p = transform.position;
		
		
		//up and down collision
		grounded = false;
		for (int i = 0; i < 3; i++) {
			float dir = Mathf.Sign(deltaY);
			float x = (p.x + center.x - size.x/2) + size.x/2 * i;
			float y = p.y + center.y +size.y/2 * dir;
			
			ray = new Ray(new Vector2(x, y), new Vector2(0, dir));
			//Debug.DrawRay(ray.origin, ray.direction);
			
			
			if(Physics.Raycast (ray, out hit, Mathf.Abs(deltaY) + skin, blueCollision) && _Self.color == ColorType.Blue) {
				float dist = Vector3.Distance(ray.origin, hit.point);
				
				if(dist > skin) {
					deltaY = dist * dir - skin * dir;
				}
				
				else {
					Destroy(gameObject);
				}
				
				grounded = true;
				break;
			}

			if(Physics.Raycast (ray, out hit, Mathf.Abs(deltaY) + skin, redCollision) && _Self.color == ColorType.Red) {
				float dist = Vector3.Distance(ray.origin, hit.point);
				
				if(dist > skin) {
					deltaY = dist * dir - skin * dir;
				}
				
				else {
					Destroy(gameObject);
				}
				
				grounded = true;
				break;
			}

			if(Physics.Raycast (ray, out hit, Mathf.Abs(deltaY) + skin, yellowCollision) && _Self.color == ColorType.Yellow) {
				float dist = Vector3.Distance(ray.origin, hit.point);
				
				if(dist > skin) {
					deltaY = dist * dir - skin * dir;
				}
				
				else {
					Destroy(gameObject);
				}
				
				grounded = true;
				break;
			}

			if(Physics.Raycast (ray, out hit, Mathf.Abs(deltaY) + skin, greenCollision) && _Self.color == ColorType.Green) {
				float dist = Vector3.Distance(ray.origin, hit.point);
				
				if(dist > skin) {
					deltaY = dist * dir - skin * dir;
				}
				
				else {
					Destroy(gameObject);
				}
				
				grounded = true;
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
				//Debug.DrawRay (ray.origin, ray.direction);
				
				
				if (Physics.Raycast (ray, out hit, Mathf.Abs (deltaX) + skin, blueCollision) && _Self.color == ColorType.Blue) {
					float dist = Vector3.Distance (ray.origin, hit.point);

					if (dist > skin) {
						deltaX = dist * dir - skin * dir;
					} 

					else {
						Destroy(gameObject);
					}
					
					
					break;
				}

				if (Physics.Raycast (ray, out hit, Mathf.Abs (deltaX) + skin, redCollision) && _Self.color == ColorType.Red) {
					float dist = Vector3.Distance (ray.origin, hit.point);
					
					if (dist > skin) {
						deltaX = dist * dir - skin * dir;
					} 
					
					else {
						Destroy(gameObject);
					}
					
					
					break;
				}

				if (Physics.Raycast (ray, out hit, Mathf.Abs (deltaX) + skin, yellowCollision) && _Self.color == ColorType.Yellow) {
					float dist = Vector3.Distance (ray.origin, hit.point);
					
					if (dist > skin) {
						deltaX = dist * dir - skin * dir;
					} 
					
					else {
						Destroy(gameObject);
					}
					
					
					break;
				}

				if (Physics.Raycast (ray, out hit, Mathf.Abs (deltaX) + skin, greenCollision) && _Self.color == ColorType.Green) {
					float dist = Vector3.Distance (ray.origin, hit.point);
					
					if (dist > skin) {
						deltaX = dist * dir - skin * dir;
					} 
					
					else {
						Destroy(gameObject);
					}
					
					
					break;
				}
			}
		}

		Vector3 enemyDir = new Vector3 (deltaX, deltaY);
		Vector3 o = new Vector3 (p.x + center.x * Mathf.Sign(deltaX), p.y + center.y * Mathf.Sign(deltaY));
		Debug.DrawRay (o, enemyDir.normalized);

		ray = new Ray (o, enemyDir.normalized);

		if (Physics.Raycast (ray, Mathf.Sqrt (deltaX * deltaX + deltaY * deltaY), blueCollision) && _Self.color == ColorType.Blue) {
			Destroy(gameObject);
		}
		if (Physics.Raycast (ray, Mathf.Sqrt (deltaX * deltaX + deltaY * deltaY), redCollision) && _Self.color == ColorType.Red) {
			Destroy(gameObject);
		}
		if (Physics.Raycast (ray, Mathf.Sqrt (deltaX * deltaX + deltaY * deltaY), yellowCollision) && _Self.color == ColorType.Yellow) {
			Destroy(gameObject);
		}
		if (Physics.Raycast (ray, Mathf.Sqrt (deltaX * deltaX + deltaY * deltaY), greenCollision) && _Self.color == ColorType.Green) {
			Destroy(gameObject);
		}
		
		

		

		
		jumpTime -= Time.deltaTime;
		//if (jumpTime <= 0 && grounded) {
		if(grounded){
			//anim.SetTrigger("landed");
		}
		
		
		
		Vector2 finalTransform = new Vector2 (deltaX, deltaY);
		
		transform.Translate(finalTransform);
	}
}
