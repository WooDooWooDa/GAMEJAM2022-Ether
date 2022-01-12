using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float _speed = 10f;
	[SerializeField] private Animator _animator;
	[SerializeField] private Rigidbody2D _rb;
	[SerializeField]private GameObject _camera;

	private bool _isMoving;
	private Vector2 _movement;
	
	private void Start()
	{
		_camera.GetComponent<CameraControl>().target = gameObject;
	}

	private void Update()
	{
		_animator.SetFloat("MovementX", _movement.x);
		_animator.SetFloat("MovementY", _movement.y);
		_animator.SetBool("IsMoving", _isMoving);
		
		_isMoving = _rb.velocity.x != 0 || _rb.velocity.y != 0;
	}
	
	private void FixedUpdate()
	{
		Move();
	}
	
	private void Move()
	{
		_movement.x = Input.GetAxisRaw("Horizontal");
		_movement.y = Input.GetAxisRaw("Vertical");

		_rb.velocity = new Vector2(_movement.x * _speed / 2, _movement.y * _speed / 2);
	}
}
