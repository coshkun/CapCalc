using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GUI_Panel : MonoBehaviour {
	
	public bool DebugMode = false;
	public string Caption = "Panel Name";
	public Texture2D ButtonImage = null;
	public Rect Position= new Rect (10, 10, Screen.width - 20, Screen.height - 20);
	public bool AutoDrawMode = false;
	private Rect currentPosition;
	public GUISkin skin = null;
	
	// Use this for initialization
	void Start () {
		currentPosition= Position;
	}
	
	// Update is called once per frame
	void Update () {
		currentPosition= new Rect (10, 10, Screen.width - 20, Screen.height - 20);
	}
	
	private void OnGUI()
	{
		GUI.skin = skin;
		if (DebugMode || Application.isPlaying) 
		{	// Apply debug mode to view changes on editor
			
			// Make a background for the interface
			if (AutoDrawMode)
				GUI.Box (currentPosition, Caption);
			else
				GUI.Box (Position, Caption);
		}
	}
}
