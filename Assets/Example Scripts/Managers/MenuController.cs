using UnityEngine;
using System.Collections;

//------------------------------------------------------------------------------
// class definition
//------------------------------------------------------------------------------
public class MenuController : MonoBehaviour
{
	// singleton instance
	static private MenuController menuController;
	public Texture2D backgroundTexture;
	public GUIStyle buttonStyle;
	
	private Rect screenRect;

	//--------------------------------------------------------------------------
	// public static methods
	//--------------------------------------------------------------------------
	//--------------------------------------------------------------------------
	// protected mono methods
	//--------------------------------------------------------------------------
	protected void Awake()
	{
		// set my singleton instance
		menuController = this;
		screenRect = new Rect( 0, 0, Screen.width, Screen.height );
	}
	
	protected void OnDestroy()
	{
		if(menuController != null)
		{
			menuController = null;
		}
	}
	
	protected void OnGUI()
	{
		if( backgroundTexture != null )
		{
			GUI.DrawTexture( screenRect, backgroundTexture );
		}
		// Make a group at screen center
		GUI.BeginGroup (new Rect (Screen.width/2 - 100, Screen.height/2 - 100, 200, 200));
		

			if (GUI.Button (new Rect(0,100,200,70), "", buttonStyle))
			{
				MainController.SwitchScene("Game Scene");
			}
	
		// End the group.
		GUI.EndGroup ();
	}
	
	protected void Start()
	{
	}
	
	protected void Update()
	{
//		if(Input.GetMouseButtonDown(0) == true)
//		{
//			MainController.SwitchScene("Game Scene");
//		}
	}

	//--------------------------------------------------------------------------
	// private methods
	//--------------------------------------------------------------------------
}
