using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//------------------------------------------------------------------------------
// class definition
//------------------------------------------------------------------------------
public class EnemyBulletController : MonoBehaviour 
{

	// singleton list to hold a reference to all of our EnemyBulletControllers
	static private List<EnemyBulletController> enemyBulletControllers;

	// my current movement velocity
	public float Speed = 10.0f;

	//--------------------------------------------------------------------------
	// static public methods
	//--------------------------------------------------------------------------
	static public EnemyBulletController Spawn(Vector3 location)
	{
		// search for the first free enemyBulletController
		foreach(EnemyBulletController enemyBulletController in enemyBulletControllers)
		{
			// if disabled, then it's available
			if(enemyBulletController.gameObject.activeSelf == false)
			{
				// set it up
				enemyBulletController.transform.position = location;

				// switch it back on
				enemyBulletController.gameObject.SetActive(true);
				
				// return a reference to the caller
				return enemyBulletController;
			}
		}
		// we normally wouldn't get here unless the enemy is firing rapidly
		// in some games we always want the pool request to succeed, if so
		// then we would instantiate another one here if we needed
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
		if(enemyBulletControllers == null)
		{
			// lazy initialize it
			enemyBulletControllers = new List<EnemyBulletController>();
		}
		// add myself to the pool
		enemyBulletControllers.Add(this);
	}
	
	protected void OnBecameInvisible()
	{
		gameObject.SetActive(false);	
	}
		
	protected void OnDestroy()
	{
		// remove myself from the pool
		enemyBulletControllers.Remove(this);
		// was I the last one?
		if(enemyBulletControllers.Count == 0)
		{
			// remove the pool itself
			enemyBulletControllers = null;
		}
	}
	
	protected void Start()
	{
		gameObject.SetActive(false);
	}
	
	protected void Update()
	{
		// travel in a straight line at 15 units per second
		transform.position -= transform.up * (Time.deltaTime * Speed);
	}
	
	//--------------------------------------------------------------------------
	// private methods
	//--------------------------------------------------------------------------
}

