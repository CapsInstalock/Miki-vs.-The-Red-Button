﻿using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
	public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
	public PlayerReset pReset;

	private bool sceneStarting = true;      // Whether or not the scene is still fading in.
	public bool reset = false;
	
	
	void Awake ()
	{
		// Set the texture so that it is the the size of the screen and covers it.
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		pReset = GameObject.Find ("Player").GetComponent<PlayerReset> ();
	}
	
	
	void Update ()
	{
		// If the scene is starting...
		if (sceneStarting) {
						// ... call the StartScene function.
						StartScene ();
				}
		if (reset) {
			ResetScene ();
		}
	}
	
	
	public void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	
	public void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
	}
	
	
	void StartScene ()
	{
		// Fade the texture to clear.
		FadeToClear();
		
		// If the texture is almost clear...
		if(guiTexture.color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the GUITexture.
			guiTexture.color = Color.clear;
			guiTexture.enabled = false;
			
			// The scene is no longer starting.
			sceneStarting = false;
		}
	}
	
	public void ResetScene () {
		// Make sure the texture is enabled.
		guiTexture.enabled = true;
		
		// Start fading towards black.
		FadeToBlack();

		if (guiTexture.color.a >= 0.95f) {
			reset = false;
			sceneStarting = true;
			pReset.RestartEverything ();
		}
	}

	public void EndScene (string loadScene) {
		// Make sure the texture is enabled.
		guiTexture.enabled = true;
		
		// Start fading towards black.
		FadeToBlack();
		
		// If the screen is almost black...
		if (guiTexture.color.a >= 0.95f) {
						// ... reload the level.
						Application.LoadLevel(loadScene);
				}
	}
}