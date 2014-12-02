using UnityEngine;
using System.Collections;

public class BoundaryController : MonoBehaviour {

	EdgeCollider2D edgeCollider;

	// Use this for initialization
	void Start () {
		edgeCollider = GetComponent<EdgeCollider2D>();
	}
	
	public void DisableBoundary () {
		if (edgeCollider.isTrigger != true) {
			edgeCollider.isTrigger = true;
			StartCoroutine ("ReEnable");
		}
	}

	IEnumerator ReEnable () {
		yield return new WaitForSeconds (2);
		edgeCollider.isTrigger = false;
	}
}
