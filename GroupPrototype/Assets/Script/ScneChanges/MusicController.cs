using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		GameObject myMusic = GameObject.Find ("Music");
		DontDestroyOnLoad (myMusic);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
