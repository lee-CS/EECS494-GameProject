using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float MaxHealth = 100;
	private float health;
	private bool tookDmgLastFramePre = false;
	private bool tookDmgLastFrameSus = false;

	// Tells the object to sustain damage
	public void takeHit(float damage) {
		tookDmgLastFramePre = true;
		health -= damage;
	}

	// Heals the given amount
	public void heal(float amt) {
		health += amt;
	}

	// reutrns whether or not the object is out of health
	public bool isDead() {
		return health < 0;
	}


	public bool tookDamageLastFrame() {
		return tookDmgLastFrameSus;
	}


	// returns current health count;
	public float get() {
		return health;
	}

	// returns the current fraction of health remaining
	public float getHealthFraction() {
		return health / MaxHealth;
	}







	void Awake() {
		health = MaxHealth;
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health > MaxHealth) {
			health = MaxHealth;
		}
	}

	void LateUpdate() {
		if (tookDmgLastFrameSus) {
			tookDmgLastFrameSus = false;
		}

		if (tookDmgLastFramePre) {
			tookDmgLastFramePre = false;
			tookDmgLastFrameSus = true;
		}
	}
}
