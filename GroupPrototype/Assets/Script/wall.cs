using UnityEngine;
using System.Collections;

public class wall : MonoBehaviour {

	public bool underConstruction  = true;
	public bool disappear  = false;

	public string color;

	private float timeCount = 0.0f;
	private float time = 3.2f;

	private Color red_color = new Color(1, 0, 0, 1);
	private Color yellow_color = new Color(1, 1, 0, 1);
	private Color green_color = new Color(0, 1, 0, 1);
	private Color blue_color = new Color(0, 0, 1, 1);
	
	// Use this for initialization
	void Start () {
		//Color temp = renderer.material.color; 
		gameObject.renderer.material.color = new Color(gameObject.renderer.material.color.r,
		                                               gameObject.renderer.material.color.g,
		                                               gameObject.renderer.material.color.b,
		                                               0);



		//renderer.material.color = temp;



		transform.localRotation = Quaternion.Euler (0, 0, Util.getAngleVector (transform.position, GameObject.FindGameObjectWithTag ("Crystal").transform.position));	 
	}

	// Update is called once per frame
	void Update () {

		if (!underConstruction) {
			timeCount += Time.deltaTime;
			if (timeCount > time) {
				disappear = true;
			}
		}
		else {
			if (renderer.material.color.a < 1.0f) {
				Color temp = renderer.material.color; 
				temp.a += 0.02f;
				renderer.material.color = temp;	
			}
			else{
				if(color == "red")
					gameObject.layer = 11;
				if(color == "yellow")
					gameObject.layer = 10;
				if(color == "green")
					gameObject.layer = 9;
				if(color == "blue")
					gameObject.layer = 8;

				underConstruction = false;
			}
		}

		if (disappear) {
			if (renderer.material.color.a > 0.0f) {
				Color temp = renderer.material.color; 
				temp.a -= 0.05f;
				renderer.material.color = temp;	
			}
			else
				Destroy (this.gameObject);
		}
	}
}
