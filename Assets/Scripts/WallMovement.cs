using UnityEngine;
using System.Collections;

public class WallMovement : MonoBehaviour {

	private bool canMove;
	public bool inward;
	public float velocity = 4.0f;
	private Vector3 _velocityVector = Vector3.zero;
	public float delay;
	Rigidbody2D _rigidbody;
	float
		_horizontalAxis = 0,
		_horizontalAxisAbsolute = 0,
		_verticalAxis = 0,
		_verticalAxisAbsolute = 0;

	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody2D>();
		if (_rigidbody == null)
			_rigidbody = gameObject.AddComponent<Rigidbody2D>();
		_rigidbody.fixedAngle = true;
		//_rigidbody.isKinematic = true;
		_rigidbody.gravityScale = 0;
		StartCoroutine("Flip");
		canMove = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (canMove) {
			UpdateWall ();
		}
	}
	
	void FixedUpdate () {
		_rigidbody.velocity = _velocityVector;
	}

	void UpdateWall () {
		if (inward) {
			_verticalAxis = -0.2f;
			_horizontalAxis = 0.3f;
		} 
		else {
			_verticalAxis = 0.2f;
			_horizontalAxis = -0.3f;
		}
		_horizontalAxisAbsolute = Mathf.Abs(_horizontalAxis);
		_verticalAxisAbsolute = Mathf.Abs(_verticalAxis);
		if (_horizontalAxisAbsolute < 0.1f && _verticalAxisAbsolute < 0.1f) {
			_velocityVector = Vector3.zero;
		}
		Vector3 vetorHorizontal = Vector3.right * velocity * _horizontalAxis;
		Vector3 vetorVertical = Vector3.up * velocity * _verticalAxis;
		_velocityVector = Vector3.ClampMagnitude(vetorHorizontal + vetorVertical, velocity);
	}

	IEnumerator Flip () {
		yield return new WaitForSeconds(delay);
		inward = !inward;
		StartCoroutine ("Flip");
	}
}