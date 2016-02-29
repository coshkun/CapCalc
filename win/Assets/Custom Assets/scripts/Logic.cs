using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
// using Gtk;

public static class Logic // : MonoBehaviour 
{
	private static FileInfo fi;
	private static string _dIR = Path.GetFullPath (new System.Uri(
													Path.Combine (Path.GetDirectoryName (Application.dataPath), "./")
													).AbsolutePath);
	// Proberty :)
	public static string _DIR {
		get { return _dIR; }
	}

	// Application.dataPath;//Directory.GetCurrentDirectory();

	public static void CreateFile()
	{
		fi = new FileInfo(_dIR + "datagrid.xml");
		if (!fi.Exists)
			fi.Create ();
	}

	public static string ShowCmdMessage(string _wD)
	{
		return "RunningOn: " + _wD;
	}

	public static string GetWorkingDirectory()
	{
		return Path.GetFullPath (
			new System.Uri 
			(
				Path.Combine (Path.GetDirectoryName (Application.dataPath), "./")
			).AbsolutePath);
	}

}
