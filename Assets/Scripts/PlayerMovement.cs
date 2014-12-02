using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public enum EnumPlayerState : int {
		IDLE = 0,
		RIGHT,
		RIGHT_DOWN,
		RIGHT_UP,
		LEFT,
		LEFT_DOWN,
		LEFT_UP,
		DOWN,
		UP
	};
	
	public float _velocity = 2.0f;
	public bool canMove;
	private Vector3 _velocityVector = Vector3.zero;
	private EnumPlayerState _stateAnimation = EnumPlayerState.IDLE;
	private Animator _scriptAnimator = null;
	Rigidbody2D _rigidbody;
	float
		_horizontalAxis = 0,
		_horizontalAxisAbsolute = 0,
		_verticalAxis = 0,
		_verticalAxisAbsolute = 0;
	
	// Use this for initialization
	void Start() {
		_scriptAnimator = GetComponent<Animator>();
		_rigidbody = GetComponent<Rigidbody2D>();
		if (_rigidbody == null)
			_rigidbody = gameObject.AddComponent<Rigidbody2D>();
		_rigidbody.fixedAngle = true;
		_rigidbody.gravityScale = 0;
		canMove = true;
	}
	
	// Update is called once per frame
	void Update() {
		if (canMove) {
			UpdateInput ();
		}
	}
	
	void FixedUpdate() {
		_rigidbody.velocity = _velocityVector;
	}
	
	void UpdateInput() {
		_verticalAxis = Input.GetAxis("Vertical");
		_horizontalAxis = Input.GetAxis("Horizontal");
		_horizontalAxisAbsolute = Mathf.Abs(_horizontalAxis);
		_verticalAxisAbsolute = Mathf.Abs(_verticalAxis);
		if (_horizontalAxisAbsolute < 0.1f && _verticalAxisAbsolute < 0.1f) {
			_velocityVector = Vector3.zero;
			_stateAnimation = EnumPlayerState.IDLE;
			_scriptAnimator.SetInteger (Animator.StringToHash ("stateAnimation"), (int)_stateAnimation);
			if (_scriptAnimator)
				_scriptAnimator.speed = 0;
		}
		else {
			if (_scriptAnimator)
				_scriptAnimator.speed = 1;
			if (_horizontalAxis >= 0.1f && _verticalAxisAbsolute < 0.4f) {
				// Right direction
				_stateAnimation = EnumPlayerState.RIGHT;
			}
			if (_horizontalAxis <= -0.1f && _verticalAxisAbsolute < 0.4f) {
				// Left direction
				_stateAnimation = EnumPlayerState.LEFT;
			}
			else if (_horizontalAxis >= 0.1f && _verticalAxis >= 0.4f) {
				_stateAnimation = EnumPlayerState.RIGHT_UP;
			}
			else if (_horizontalAxis >= 0.1f && _verticalAxis <= -0.4f) {
				_stateAnimation = EnumPlayerState.RIGHT_DOWN;
			}
			else if (_horizontalAxis <= -0.1f && _verticalAxis >= 0.4f) {
				_stateAnimation = EnumPlayerState.LEFT_UP;
			}
			else if (_horizontalAxis <= -0.1f && _verticalAxis <= -0.4f) {
				_stateAnimation = EnumPlayerState.LEFT_DOWN;
			}
			else if (_verticalAxis <= -0.1f && _horizontalAxisAbsolute < 0.4f) {
				// Down direction
				_stateAnimation = EnumPlayerState.DOWN;
			}
			else if (_verticalAxis >= -0.1f && _horizontalAxisAbsolute < 0.4f) {
				// Up direction
				_stateAnimation = EnumPlayerState.UP;
			}
			_scriptAnimator.SetInteger (Animator.StringToHash ("stateAnimation"), (int)_stateAnimation);
			Vector3 vetorHorizontal = Vector3.right * _velocity * _horizontalAxis;
			Vector3 vetorVertical = Vector3.up * _velocity * _verticalAxis;
			_velocityVector = Vector3.ClampMagnitude(vetorHorizontal + vetorVertical, _velocity); ;
		}
	}
}
