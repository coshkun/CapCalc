using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GUI_Label : MonoBehaviour {

	public bool DebugMode = false;
	public string Caption = "Label Name";
	private static string _caption = "";
	private static float _padding = (_caption.Length + 10.0f) * 0.5f;
	public Rect Position= new Rect ((Screen.width * 0.5f - 8*_padding), (Screen.height * 0.5f), (16*_padding), 20);
	public bool AutoDrawMode = false;
	private Rect currentPosition;
	public GUISkin skin = null;

	public string AutoDrawCommand = "CenterScreen";

	// Use this for initialization
	void Start () {
		_caption = Caption;
		Position = new Rect ((Screen.width * 0.5f - 8*_padding), (Screen.height * 0.5f), (16*_padding), 20);
	}

	void Update () {

        switch (AutoDrawCommand) {
		case "CenterScreen":
			currentPosition= new Rect ((Screen.width * 0.5f - 8*_padding), (Screen.height * 0.5f), (16*_padding), 20);
			break;
		case "CenterTop":
			currentPosition= new Rect ((Screen.width * 0.5f - 8*_padding),  10.0f , (16*_padding), 20);
			break;
		case "CenterBottom":
			currentPosition= new Rect ((Screen.width * 0.5f - 8*_padding), (Screen.height - 50.0f), (16*_padding), 20);
			break;
		case "LeftBottom":
			currentPosition= new Rect (10.0f, (Screen.height - 50.0f), (16*_padding), 20);
			break;
		case "CommandPrompt":
			float _cmdLeft = 10.0f; //Block for screen overlay
			if ((Screen.width * 0.2f - 8*_padding)>10.0f) {_cmdLeft = (Screen.width * 0.2f - 8*_padding);} else {_cmdLeft = 10.0f;}
			currentPosition= new Rect (_cmdLeft, (Screen.height - 50.0f), (16*_padding), 20);
			break;

		default:
			currentPosition= new Rect ((Screen.width * 0.5f - 8*_padding), (Screen.height * 0.5f), (16*_padding), 20);
			break;
		}
	}

	void OnGUI () {
		GUI.skin = skin;
		if (DebugMode || Application.isPlaying) 
		{   // Apply debug mode to view changes on editor

            if (AutoDrawCommand == "CommandPrompt")
            {
                _caption = Logic.ShowCmdMessage(Logic._DIR);
            }
            else { _caption = Caption; }
			// Make a background for the interface
			if (AutoDrawMode){ GUI.Label (currentPosition, _caption);}
			else {GUI.Label (Position, _caption);}
		}
	}
}
