using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//------------------------------------------------------------------------------
// class definition
//------------------------------------------------------------------------------
public class PlayerBulletController : MonoBehaviour 
{

	// singleton list to hold a reference to all of our PlayerBulletControllers
	static private List<PlayerBulletController> playerBulletControllers;

	// my current movement velocity
	public float Speed = 10.0f;

	//--------------------------------------------------------------------------
	// static public methods
	//--------------------------------------------------------------------------
	static public PlayerBulletController Spawn(Vector3 location)
	{
		// search for the first free playerBulletController
		foreach(PlayerBulletController playerBulletController in playerBulletControllers)
		{
			// if disabled, then it's available
			if(playerBulletController.gameObject.activeSelf == false)
			{
				// set it up
				playerBulletController.transform.position = location;

				// switch it back on
				playerBulletController.gameObject.SetActive(true);
				
				// return a reference to the caller
				return playerBulletController;
			}
		}
		// we normally wouldn't get here unless the player is firing rapidly
		// in some games we always want the pool request to succeed, if so
		// then we would instantiate another one here if we needed
		// in our case, it's part of the design that you can only have
		// a limited number of shots active at any one time
		return null;
	}
	
	//--------------------------------------------------------------------------
	// static private methods
	//--------------------------------------------------------------------------

	//--------------------------------------------------------------------------
	// protected mono methods
	//--------------------------------------------------------------------------
	protected void Awake()
	{
		// does the pool exist yet?
		if(playerBulletControllers == null)
		{
			// lazy initialize it
			playerBulletControllers = new List<PlayerBulletController>();
		}
		// add myself to the pool
		playerBulletControllers.Add(this);
	}
	
	protected void OnBecameInvisible()
	{
		gameObject.SetActive(false);
	}
	
	protected void OnDestroy()
	{
		// remove myself from the pool
		playerBulletControllers.Remove(this);
		// was I the last one?
		if(playerBulletControllers.Count == 0)
		{
			// remove the pool itself
			playerBulletControllers = null;
		}
	}
	
	protected void OnTriggerEnter(Collider collider)
	{
		// if I touched something, hide myself and return to the pool
		gameObject.SetActive(false);
	}
	
	protected void Start()
	{
		gameObject.SetActive(false);
	}
	
	protected void Update()
	{
		// travel in a straight line at Speed units per second
		transform.position += transform.up * (Time.deltaTime * Speed);
	}
	
	//--------------------------------------------------------------------------
	// private methods
	//--------------------------------------------------------------------------
}
