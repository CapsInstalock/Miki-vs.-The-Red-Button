using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public ScreenFader fader;
	public string nextLevel = "Level 2";

	public Sprite unpressed, pressed;
	private bool activated;

	void Awake () {
		fader = GameObject.Find ("Screen Fader").GetComponent<ScreenFader>();
	}

	public void UnpressButton () {
		GetComponent<SpriteRenderer> ().sprite = unpressed;
		GetComponent<BoxCollider2D> ().isTrigger = true;
		activated = true;
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player") && activated) {
			fader.EndScene (nextLevel);
			//Application.LoadLevel (nextLevel);
		}
	}
}
