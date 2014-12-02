using UnityEngine;
using System.Collections;

public class Screw : MonoBehaviour {

	private GameObject manager;
	private GameManager gameManager;

	void Awake () {
		if (manager == null) {
			manager = GameObject.FindWithTag ("GameController");
			if (gameManager == null) {
				gameManager = manager.GetComponent<GameManager>();
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			gameManager.getScrew ();
			gameObject.SetActive (false);
		}
	}
}
