using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//------------------------------------------------------------------------------
// class definition
//------------------------------------------------------------------------------
public class EnemyShipController : MonoBehaviour 
{

	// singleton list to hold a reference to all of our EnemyShipControllers
	static private List<EnemyShipController> enemyShipControllers;

	static private int activeCount;
	
	private Vector3 destination;
	private float holdTimer;
	private float fireTimer;
	private delegate void UpdateDelegate();
	private UpdateDelegate updateDelegate;
	public float MinFireTime = 1.0f;
	public float MaxFireTime = 2.0f;
	public float MinHoldTime = 0.5f;
	public float MaxHoldTime = 2.0f;

	//--------------------------------------------------------------------------
	// static public methods
	//--------------------------------------------------------------------------
	
	//--------------------------------------------------------------------------
	// static private methods
	//--------------------------------------------------------------------------

	//--------------------------------------------------------------------------
	// protected mono methods
	//--------------------------------------------------------------------------
	protected void Awake()
	{
		// does the pool exist yet?
		if(enemyShipControllers == null)
		{
			// lazy initialize it
			enemyShipControllers = new List<EnemyShipController>();
		}
		// add myself to the pool
		enemyShipControllers.Add(this);
		activeCount++;
	}
	
	protected void OnDestroy()
	{
		// remove myself from the pool
		enemyShipControllers.Remove(this);
		// was I the last one?
		if(enemyShipControllers.Count == 0)
		{
			// remove the pool itself
			enemyShipControllers = null;
		}
		activeCount = 0;
	}

	protected void OnTriggerEnter(Collider otherCollider)
	{
		// who hit me?
		
		// PlayerBullet
		if(otherCollider.tag == "Player Bullet")
		{
			// hide myself
			gameObject.SetActive(false);
			activeCount--;
			PlayerShipController.ChangeScore( 1 );

			// if there are no more active enemies
			if(activeCount <= 0)
			{
				// win game
				GameController.Win();
			}
		}
	}
	
	protected void Start()
	{
		updateDelegate = UpdateHold;
		holdTimer = Random.Range(MinHoldTime, MaxHoldTime);
		fireTimer = Random.Range(MinFireTime, MaxFireTime);
	}
	
	protected void Update()
	{
		if(updateDelegate != null)
		{
			updateDelegate();
		}
	}
	
	//--------------------------------------------------------------------------
	// private methods
	//--------------------------------------------------------------------------
	private void UpdateHold()
	{
		holdTimer -= Time.deltaTime;
		if(holdTimer <= 0.0f)
		{
			destination = transform.position;
			destination.x = Random.Range(-5, 5);
			updateDelegate = UpdateMove;
		}
	}
	
	private void UpdateMove()
	{
		transform.position = Vector3.MoveTowards(transform.position, destination, 4.0f * Time.deltaTime);
		if(Vector3.Distance(transform.position, destination) <= 0.1f)
		{
			holdTimer = Random.Range(MinHoldTime, MaxHoldTime);
			updateDelegate = UpdateHold;
		}

		fireTimer -= Time.deltaTime;
		if(fireTimer <= 0.0f)
		{
			EnemyBulletController.Spawn(transform.position);
			fireTimer = Random.Range(MinFireTime, MaxFireTime);
		}
			
	}
}
