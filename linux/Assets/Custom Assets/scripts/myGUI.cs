using UnityEngine;
using System.Collections;

public class myGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		// Make a background for the interface
		GUI.Box (new Rect (10, 10, 100, 300), "Menu");
	}
}
