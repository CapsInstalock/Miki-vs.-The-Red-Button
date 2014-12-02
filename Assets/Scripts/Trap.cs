using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

	private GameObject player;
	private GameObject explosion;
	private BoundaryController boundary;
	
	private PlayerMovement pMove;
	private PlayerReset pReset;

	void Awake () {
		if (player == null) {
			player = GameObject.Find("Player");
			explosion = GameObject.Find ("skillAttack");
			pMove = player.GetComponent<PlayerMovement>();
			pReset = player.GetComponent<PlayerReset>();
		}
		if (boundary == null) {
			boundary = GameObject.FindWithTag("Boundary").GetComponent<BoundaryController>();
		}
	}

	void Start () {
		explosion.SetActive (false);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			player.renderer.enabled = false;
			explosion.SetActive(true);
			pMove.canMove = false;
			pReset.Reset ();
		}
	}
}
