using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	private static bool Created = false;

	void Awake () {
		if (!Created) {
			// If this is the first object, keep this object in all scenes after the title screen
			DontDestroyOnLoad(transform.gameObject);
			Created = true;
		}
		else {
			// Another Music Manager exists, destroy this instance
			Destroy (this.gameObject);
		}
	}
}
