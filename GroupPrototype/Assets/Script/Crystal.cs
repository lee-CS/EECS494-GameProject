using UnityEngine;
using System.Collections;

public class Crystal : MonoBehaviour {



	Health health;

	// Use this for initialization
	void Start () {
		health = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
		if (health.isDead ()) {
			Destroy(gameObject);
		}

	}
	
}

