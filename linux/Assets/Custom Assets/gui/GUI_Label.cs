using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GUI_Label : MonoBehaviour {

	public bool DebugMode = false;
	public string Caption = "Label Name";
	private static string _caption = "";
	private static float _padding = (float)_caption.Length * 0.5f;
	public Rect Position= new Rect (((Screen.width * 0.5f) - _padding), (Screen.height * 0.5f), (2 * _padding), 20);
	public bool AutoDrawMode = false;
	private Rect currentPosition;
	public GUISkin skin = null;

	// Use this for initialization
	void Start () {
		_caption = Caption;
		currentPosition= Position;
	}

	void Update () {
		currentPosition= new Rect (((Screen.width * 0.5f) - _padding), (Screen.height * 0.5f), (2 * _padding), 20);
	}

	void OnGUI () {
		GUI.skin = skin;
		if (DebugMode || Application.isPlaying) 
		{	// Apply debug mode to view changes on editor
			
			// Make a background for the interface
			if (AutoDrawMode)
				GUI.Label (currentPosition, _caption);
			else
				GUI.Label (Position, _caption);
		}
	}
}
