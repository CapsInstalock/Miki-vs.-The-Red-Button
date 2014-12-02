using UnityEngine;
using System.Collections;

public class TitleButton : MonoBehaviour {

	public Sprite unpressed, pressed;

	void OnMouseDown () {
		GetComponent<SpriteRenderer> ().sprite = pressed;
	}

	void OnMouseUp () {
		GetComponent<SpriteRenderer> ().sprite = unpressed;
	}
}
