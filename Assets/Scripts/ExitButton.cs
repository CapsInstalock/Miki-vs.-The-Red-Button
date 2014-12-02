using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

	public Texture unpressed, pressed;

	void OnMouseDown () {
		GetComponent<GUITexture> ().texture = pressed;
		Application.Quit ();
	}

	void OnMouseUp () {
		GetComponent<GUITexture> ().texture = unpressed;
	}
}
