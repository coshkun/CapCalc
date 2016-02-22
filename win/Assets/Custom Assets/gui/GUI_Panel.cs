using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GUI_Panel : MonoBehaviour {
	
	public bool DebugMode = false;
	public string Caption = "Panel Name";
	public Texture2D ButtonImage = null;
	public Rect Position= new Rect (10, 10, Screen.width - 20.0f, Screen.height - 20.0f);
	public bool AutoDrawMode = false;
	private Rect currentPosition;
	public GUISkin skin = null;

    public string AutoDrawCommand = "CommandPrompt";

    // Use this for initialization
    void Start () {
		currentPosition= Position;
	}
	
	// Update is called once per frame
	void Update () {
		currentPosition= new Rect (10, 10, Screen.width - 20.0f, Screen.height - 20.0f);

        switch (AutoDrawCommand)
        {
            case "CenterScreen":
                currentPosition = new Rect((Screen.width * 0.5f - Position.width * 0.5f),
                                            (Screen.height * 0.5f - Position.height *0.5f), Position.width, Position.height);
                break;
            case "CenterTop":
                currentPosition = new Rect((Screen.width * 0.5f - Position.width * 0.5f),
                                            10.0f , Position.width, Position.height);
                break;
            case "CenterBottom":
                currentPosition = new Rect((Screen.width * 0.5f - Position.width * 0.5f),
                                            (Screen.height - Position.height) - 10.0f, Position.width, Position.height);
                break;
            case "LeftBottom":
                currentPosition = new Rect(10.0f,
                                            (Screen.height - Position.height) - 10.0f, Position.width, Position.height);
                break;
            case "CommandPrompt":
                float _cmdLeft = 10.0f; //Block for screen overlay
                if ((Position.x) >= 10.0f) { _cmdLeft = (Screen.width * 0.5f - Position.width * 0.5f); }
                else if ((Position.x) < 10.0f) { _cmdLeft = 10.0f; }
                currentPosition = new Rect(_cmdLeft, (Screen.height - Position.height) - 10.0f, Position.width, Position.height);
                break;

            default:
                currentPosition = Position;
                break;
        }
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
