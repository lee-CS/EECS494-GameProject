using UnityEngine;
using System.Collections;


/* A health bar.
 * The parent MUST have a Health component!
 * 
 */
public class HealthBar : MonoBehaviour {

	public Color emptyColor;
	public Color fullColor;

	Health parentHealth;

	MeshRenderer baseBar;
	MeshRenderer overlayBar;

	float overlayZ = -3;
	float baseZ = -2;

	float barWidth = 4;
	float barHeight = .1f;


	// Use this for initialization
	void Start () {
		parentHealth = transform.parent.gameObject.GetComponent<Health>();

		MeshRenderer[] rends = GetComponentsInChildren<MeshRenderer>();
		baseBar = rends[0];
		overlayBar = rends[1];



		baseBar.transform.localScale    = new Vector3(barWidth, barHeight, 1);
		overlayBar.transform.localScale = new Vector3(barWidth, barHeight, 1);

		baseBar.material.color = emptyColor;
		overlayBar.material.color = fullColor;
	}
	
	// Update is called once per frame
	void Update () {
		baseBar.transform.position = gameObject.transform.position + new Vector3(0, 0, baseZ);
		overlayBar.transform.position = gameObject.transform.position + new Vector3(
			((barWidth / 2f) * (1 - parentHealth.getHealthFraction())), 
			0, 
			overlayZ
		);

		overlayBar.transform.localScale = new Vector3(
			barWidth * parentHealth.getHealthFraction(),
			overlayBar.transform.localScale.y,
			1);


	}
}
