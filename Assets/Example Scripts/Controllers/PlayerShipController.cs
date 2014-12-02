using UnityEngine;
using System.Collections;

//------------------------------------------------------------------------------
// class definition
//------------------------------------------------------------------------------	
public class PlayerShipController : MonoBehaviour 
{
	// singleton instance
	static private PlayerShipController playerShipController;
	
	// my current movement velocity
	public float Speed = 10.0f;
	private int score;
	
	//--------------------------------------------------------------------------
	// static public methods
	//--------------------------------------------------------------------------
	static public int GetScore()
	{
		// return score
		return playerShipController.score;
	}
	
	static public void ChangeScore( int scoreDelta )
	{
		// change score
		playerShipController.score += scoreDelta;
	}

	//--------------------------------------------------------------------------
	// static private methods
	//--------------------------------------------------------------------------
	
	//--------------------------------------------------------------------------
	// protected mono methods
	//--------------------------------------------------------------------------
	protected void Awake()
	{
		// set my singleton instance
		playerShipController = this;
	}
	
	protected void OnDestroy()
	{
		// the check is to prevent warnings if otherwise unused
		if(playerShipController != null)
		{
			playerShipController = null;
		}
	}

	protected void OnTriggerEnter(Collider otherCollider)
	{
		// who hit me?
		
		// Enemy Bullet?
		if(otherCollider.CompareTag("Enemy Bullet"))
		{
			// hide myself
			gameObject.SetActive(false);
			
			// lose game
			GameController.Lose();
		}
	}
	
	protected void Start () 
	{
		
	}
	
	protected void Update () 
	{
		//Get Input
		if(Input.GetKey(KeyCode.LeftArrow) == true)
		{
			transform.Translate(Vector3.left * Time.deltaTime * Speed);
		}
		
		if(Input.GetKey(KeyCode.RightArrow) == true)
		{
			transform.Translate(Vector3.right * Time.deltaTime * Speed);
		}

		//Clamp Position
		Vector3 newPosition = transform.localPosition;
		newPosition.x = Mathf.Clamp( newPosition.x, -5.0f, 5.0f );
		transform.localPosition = newPosition;

		//Fire
		if(Input.GetKeyDown(KeyCode.Space) == true)
		{
			//we just request a playerBullet, whether it fires or not depends on if one is free.
			PlayerBulletController.Spawn(transform.position);
		}
	}
	
	//--------------------------------------------------------------------------
	// private methods
	//--------------------------------------------------------------------------
}



