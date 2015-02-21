using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

	private Transform target;
	public float trackSpeed = 50; 


	public void SetTarget(Transform t) {
		target = t;
	}

	void LateUpdate(){
		if (target) {

			//if we want the camera to follow a player
			float x = distance (transform.position.x, target.position.x, trackSpeed);
			float y = distance (transform.position.y, target.position.y, trackSpeed);


			//right now centering around crystal
			x = 0;
			y = 0;
				
			transform.position = new Vector3(x,y, transform.position.z);

		}
	}


	private float distance(float n, float target, float acc) {
		if (n == target)
			return n;
		else {
			float dir = Mathf.Sign (target - n);
			n += acc * Time.deltaTime * dir;
			return (dir == Mathf.Sign (target - n)) ? n : target;
		}
	}
}
