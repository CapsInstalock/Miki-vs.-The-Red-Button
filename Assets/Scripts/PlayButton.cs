using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	public SceneController sceneController;
	public Texture unpressed, pressed;
	public GUITexture play, exit;
	public SpriteRenderer help;

	void OnMouseDown () {
		GetComponent<GUITexture> ().texture = pressed;
		play.enabled = false;
		exit.enabled = false;
		help.enabled = true;
		StartCoroutine ("StartGame");
	}

	void OnMouseUp () {
		GetComponent<GUITexture> ().texture = unpressed;
	}

	IEnumerator StartGame () {
		yield return new WaitForSeconds (3);
		Application.LoadLevel ("Level 1");
	}
}
