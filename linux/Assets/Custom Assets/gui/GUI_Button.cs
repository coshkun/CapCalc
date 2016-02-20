using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GUI_Button : MonoBehaviour {

	public bool DebugMode = false;
	public string Caption = "Button";
	public Texture2D ButtonImage = null;
	public Rect Position = new Rect (10, 50, 100, 25);

	public GUISkin skin = null;

	// Use this for instancetiating
	private void OnGUI()
	{
		if (DebugMode || Application.isPlaying) 
		{	// Apply debug mode to view changes on editor

			GUI.skin = skin;
			// Draw with a background
			if(ButtonImage != null)
			{
				if(GUI.Button (Position, ButtonImage)){ CallButtonAction();}
			}
			// Draw with text only
			else 
			{
				if(GUI.Button (Position, Caption)){ CallButtonAction();}
			}
		}
	}

	private void CallButtonAction()
	{
		switch (Caption) {
		case "Exit":
			Application.Quit();
			break;
		default:
			break;
		}
	}
}
