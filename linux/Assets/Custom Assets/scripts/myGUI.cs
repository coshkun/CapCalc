using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class myGUI : MonoBehaviour {

	public bool DebugMode = false;
	public string Caption = "Panel Name";
	public Texture2D ButtonImage = null;
	public Rect Position = new Rect (10, 10, Screen.width - 20, Screen.height - 50);
	
	void OnGUI(){

		if (DebugMode || Application.isPlaying) 
		{	// Apply debug mode to view changes on editor

			// Make a background for the interface
			GUI.Box (Position, Caption);

		}
	}
}
