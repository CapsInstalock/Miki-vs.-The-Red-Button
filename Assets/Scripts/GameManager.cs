using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private static GameManager gameManager;
	private Button button;
	private int screws;
	public int screwGoal;

	public GUITexture texture;
	public Texture none, one, two, three;
	public GUIText screwText;

	protected void Awake () {
		gameManager = this;
		button = GameObject.Find ("Big Red Button").GetComponent<Button> ();
	}

	protected void OnDestroy () {
		if (gameManager != null) {
			gameManager = null;
		}
	}

	//If a key is found
	public void getScrew () {
		screws++;
		UpdateScrews ();
	}

	// Use this for initialization
	void Start () {
		screws = 0;
		UpdateScrews ();
	}

	void UpdateScrews () {
		if (screws == 1) {
			texture.GetComponent<GUITexture>().texture = one;
		}
		if (screws == 2) {
			texture.GetComponent<GUITexture>().texture = two;
		}
		if (screws == 3) {
			texture.GetComponent<GUITexture>().texture = three;
		}
		if (screws == screwGoal) {
			button.UnpressButton ();
		}
	}
}