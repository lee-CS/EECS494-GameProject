using UnityEngine;
using System.Collections;

public class spawner_left_right : MonoBehaviour {

	public GameObject enemy_1;
	public GameObject enemy_2;
	public GameObject enemy_3;


	public float spawnTime = 2;
	public float spawnTime2 = 3;
	public float spawnTime3 = 8;
	//public float spawnTime4 = 12;

	// Use this for initialization
	void Start() {  
		// Call the 'addEnemy' function every 'spawnTime' seconds
		InvokeRepeating("addenemy_1", spawnTime, spawnTime);

		//Type 2 enemy
		//InvokeRepeating("addenemy_2", spawnTime2, spawnTime2);


		//Type 3 enemy
		//InvokeRepeating("addenemy_3", spawnTime3, spawnTime3);


		//NOT USED FOR NOW, ADDS A LINE OF ENEMY
		//InvokeRepeating("addLine", spawnTime4, spawnTime4);
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
		Instantiate(enemy_1, spawnPoint, Quaternion.identity);
	}

	void addenemy_2() {  
		// Variables to store the X position of the spawn object
		// See image below
		var y1 = transform.position.y - renderer.bounds.size.y/2;
		var y2 = transform.position.y + renderer.bounds.size.y/2;
		
		// Randomly pick a point within the spawn object
		var spawnPoint = new Vector2(transform.position.x, Random.Range(y1, y2));
		
		// Create an enemy at the 'spawnPoint' position
		Instantiate(enemy_2, spawnPoint, Quaternion.identity);
	}


	void addenemy_3() {  
		// Variables to store the X position of the spawn object
		// See image below
		var y1 = transform.position.y - renderer.bounds.size.y/2;
		var y2 = transform.position.y + renderer.bounds.size.y/2;
		
		// Randomly pick a point within the spawn object
		var spawnPoint = new Vector2(transform.position.x, Random.Range(y1, y2));
		
		// Create an enemy at the 'spawnPoint' position
		Instantiate(enemy_3, spawnPoint, Quaternion.identity);
		
	}



	//NOT USED FOR NOW BUT IT SPAWNS A LINE OF ENEMIES
	void addLine() {  
		// Variables to store the X position of the spawn object
		// See image below
		var y1 = transform.position.y - renderer.bounds.size.y/2;
		var y2 = transform.position.y + renderer.bounds.size.y/2;
		
		// Randomly pick a point within the spawn object
		var spawnPoint = new Vector2(transform.position.x, Random.Range(y1, y2));

		var spawnPoint2 = spawnPoint;
		var spawnPoint3 = spawnPoint;
		var spawnPoint4 = spawnPoint;

		spawnPoint2.x = spawnPoint2.x + 5;
		spawnPoint3.x = spawnPoint3.x + 7;
		spawnPoint4.x = spawnPoint4.x + 9;

		// Create an enemy at the 'spawnPoint' position
		Instantiate(enemy_1, spawnPoint, Quaternion.identity);
		Instantiate(enemy_2, spawnPoint2, Quaternion.identity);
		Instantiate(enemy_2, spawnPoint3, Quaternion.identity);
		Instantiate(enemy_2, spawnPoint4, Quaternion.identity);
	}


}
