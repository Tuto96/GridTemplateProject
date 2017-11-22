using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{

	public void Open ()
	{
		gameObject.SetActive (true);
		HexMapCamera.Locked = true;
	}
	public void Close ()
	{
		gameObject.SetActive (false);
		HexMapCamera.Locked = false;
	}

	public void Exit ()
	{
		#if UNITY_EDITOR
		// Application.Quit() does not work in the editor so
		// UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit ();
		#endif
	}
}