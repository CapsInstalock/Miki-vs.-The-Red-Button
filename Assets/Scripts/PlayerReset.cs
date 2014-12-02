using UnityEngine;
using System.Collections;

public class PlayerReset : MonoBehaviour {

	private GameObject player;
	private GameObject explosion;
	private ScreenFader fade;
	private Vector3 startingPosition;
	private PlayerMovement pMove;

	// Use this for initialization
	void Awake () {
		if (player == null) {
			player = GameObject.Find("Player");
		}
		explosion = GameObject.Find ("skillAttack");
		startingPosition = player.transform.position;
		fade = GameObject.Find ("Screen Fader").GetComponent<ScreenFader>();
		pMove = GetComponent<PlayerMovement> ();
	}

	public void Reset () {
		player.rigidbody2D.velocity = Vector3.zero;
		ResetFade ();
		//StartCoroutine(Timer ());
	}

	// Resets the Player's position when called
	void ResetPosition () {
		player.transform.position = startingPosition;
	}

	void ResetMovement () {
		pMove.canMove = true;
	}

	// Resets the player's gravity
	void EnableRenderer () {
		player.renderer.enabled = true;
	}

	void ResetFade () {
		fade.reset = true;
	}

	public void RestartEverything () {
		//yield return new WaitForSeconds(2);
		explosion.SetActive (false);
		ResetPosition ();
		EnableRenderer ();
		ResetMovement ();
	}
}
