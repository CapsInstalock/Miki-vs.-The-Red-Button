using UnityEngine;
using System.Collections;

//------------------------------------------------------------------------------
// class definition
//------------------------------------------------------------------------------
public class GameController : MonoBehaviour
{
	private static GameController gameController;
	public GUIText OverlayText;

	//--------------------------------------------------------------------------
	// public static methods
	//--------------------------------------------------------------------------
	static public void Win()
	{
		gameController.StartCoroutine(gameController.WinGame());
	}

	static public void Lose()
	{
		gameController.StartCoroutine(gameController.LoseGame());
	}

	//--------------------------------------------------------------------------
	// protected mono methods
	//--------------------------------------------------------------------------
	protected void Awake()
	{
		gameController = this;
		gameController.OverlayText.text = "";
	}
	
	protected void OnDestroy()
	{
		if(gameController != null)
		{
			gameController = null;
		}
	}
	
	protected void OnDisable()
	{
	}
	
	protected void OnEnable()
	{
	}
	
	protected void Start()
	{
	}
	
	protected void Update()
	{
	}

	//--------------------------------------------------------------------------
	// private methods
	//--------------------------------------------------------------------------

	IEnumerator WinGame()
	{
		// win game
		gameController.OverlayText.text = "Victory!";
		yield return new WaitForSeconds(3);
		MainController.SwitchScene("Menu Scene");
	}

	IEnumerator LoseGame()
	{
		// win game
		gameController.OverlayText.text = "Defeat!";
		yield return new WaitForSeconds(3);
		MainController.SwitchScene("Menu Scene");
	}

}
