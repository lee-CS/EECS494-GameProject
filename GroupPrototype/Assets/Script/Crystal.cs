using UnityEngine;
using System.Collections;

public class Crystal : MonoBehaviour {



	Health health;
	HealthBar hBar;

	float showHealthTimer = 0;
	bool showingHealth = false;
	float showHealthDuration = 2f;

	// Use this for initialization
	void Start () {
		health = GetComponent<Health>();
		hBar = GetComponentInChildren<HealthBar>();
		hBar.show = false;
	}
	
	// Update is called once per frame
	void Update () {
		handleHealthBar ();


		if (health.isDead ()) {
			Destroy(gameObject);
			Application.LoadLevel ("GameOver");
		}

	}






	/* handle when to show healthBar */
	void handleHealthBar() {
		if (health.tookDamageLastFrame()) {
			showingHealth = true;
			hBar.show = true;
		}
		
		if (showingHealth) {
			showHealthTimer += Time.deltaTime;
			if (showHealthTimer > showHealthDuration) {
				hBar.show = false;
				showHealthTimer = 0f;
				showingHealth = false;
			}
		}
	}
	
}

