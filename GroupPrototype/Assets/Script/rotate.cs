using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

	private Vector3 center;
	private Vector3 initial;
	private bool init_set;

	public float angle =0;
	float speed = (2 * Mathf.PI) / 5; //2*PI in degress is 360, so you get 5 seconds to complete a circle
	float radius=20;

	// Use this for initialization
	void Start () {
		center = new Vector3(0,0,0);
		init_set = false;

	}
	
	// Update is called once per frame
	void Update () {
		angle += speed*Time.deltaTime; //if you want to switch direction, use -= instead of +=



		radius -= Time.deltaTime;

		Vector2 temp = new Vector2 (0, 0);
		temp.x = Mathf.Cos(angle)*radius;
		temp.y = Mathf.Sin(angle)*radius;

		transform.position = temp;


		
	}
}
