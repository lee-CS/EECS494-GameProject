using UnityEngine;
using System.Collections;


/* based off of spawner_left)right/up_down */
public class ProjectileSpawner : MonoBehaviour {
	
	public GameObject enemy_1;

	float currentTime = 0f;
	bool started = false;

	public float spawnDelay = 6;
	public float spawnCycle = 10;
	public float spawnTimeDelta = 0f;
	public ColorType spawnColor1;
	public ColorType spawnColor2;
	//public float spawnTime4 = 12;
	
	// Use this for initialization
	void Start() {  

	}



	void Update() {
		currentTime += Time.deltaTime;
		if (!started) {
			if (currentTime > spawnDelay) {
				started = true;
				currentTime = 0f;
			}
			return;
		}

		if (currentTime > spawnCycle) {
			addenemy_1 ();
			currentTime = 0f;
		}



	}

	// New function to spawn an enemy
	void addenemy_1() {  
		// Variables to store the X position of the spawn object
		// See image below
		var y1 = transform.position.y - renderer.bounds.size.y/2;
		var y2 = transform.position.y + renderer.bounds.size.y/2;
		
		// Randomly pick a point within the spawn object
		var spawnPoint = new Vector2(transform.position.x, Random.Range(y1, y2));
		
		// Create an enemy at the 'spawnPoint' position
		GameObject res = (GameObject)Instantiate(enemy_1, spawnPoint, Quaternion.identity);
		res.GetComponent<Projectile>().colorOverriding = true;
		res.GetComponent<Projectile>().color = (Random.value > .5? spawnColor1 : spawnColor2);

		spawnCycle += spawnTimeDelta;

	}
	

	

}
