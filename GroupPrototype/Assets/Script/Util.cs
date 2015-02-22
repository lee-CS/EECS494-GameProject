using UnityEngine;
using System.Collections;

public enum ColorType {
	Red,
	Yellow,
	Green,
	Blue,
	NumColors
};


// Class for generic utility functions
public class Util : MonoBehaviour {




	// Gets  the degree of rotation between two points on the XY plane
	static public float getAngleVector(Vector3 destination, Vector3 source) {	
		Vector2 a = destination - source;
		
		float angle = Vector2.Angle (new Vector3(-1, 0, 0), a.normalized);
		
		if (a.y > 0) {
			angle *= -1;
		}
		
		
		Debug.DrawLine (Vector3.zero, a.normalized);
		Debug.DrawLine (Vector3.zero, new Vector3(1, 0, 0));
		return angle;
	}


	// Returns a random color.
	static public ColorType randomColor() {
		int colorChance = (int)Random.Range(0, (int) ColorType.NumColors);
		switch(colorChance) {

		case ((int)ColorType.Red): 		return ColorType.Red; break;
		case ((int)ColorType.Yellow): 	return ColorType.Yellow; break;
		case ((int)ColorType.Green): 	return ColorType.Green; break;
		case ((int)ColorType.Blue):		return ColorType.Blue; break;

		}

		return ColorType.NumColors;
	}

	// Returns the corresponding color instance given the color enum.
	static public Color getColorObject(ColorType c) {
		switch(c) {
		case ColorType.Red: 	return new Color(1, 0, 0, 1); break;
		case ColorType.Yellow:	return new Color(1, 1, 0, 1); break;
		case ColorType.Green:	return new Color(0, 1, 0, 1); break;
		case ColorType.Blue:	return new Color(0, 0, 1, 1); break;
		

		}
		return new Color(1, 1, 1, 1);
	}


}
