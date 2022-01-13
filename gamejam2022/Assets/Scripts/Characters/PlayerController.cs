using System;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float _speed = 10f;
	[SerializeField] private Animator _animator;
	[SerializeField] private Rigidbody2D _rb;
	[SerializeField] private GameObject[] _hints;

	private bool _isMoving;
	private bool isInverted = false;
    private bool _canMove = true;
	private Vector2 _movement;
	private float _lastDirectionX; 
	private float _lastDirectionY;

	public void InvertControl()
	{
		isInverted = true;
	}

	public void TogglePlayerMovement()
	{
		_canMove = !_canMove;
		_rb.constraints = _canMove ? RigidbodyConstraints2D.FreezeRotation : RigidbodyConstraints2D.FreezeAll;
	}

	private void Update()
	{
		_animator.SetFloat("VelocityX", _movement.x);
		_animator.SetFloat("VelocityY", _movement.y);
		_isMoving = _rb.velocity.x != 0 || _rb.velocity.y != 0;
		_animator.SetBool("IsMoving", _isMoving);
		_animator.SetFloat("LastDirectionX", _lastDirectionX);
		_animator.SetFloat("LastDirectionY", _lastDirectionY);
		
		if (Input.GetButtonDown("Inspect"))
		{
			InspectLetter();
		}
	}

	private void FixedUpdate()
	{
		Move();
	}

	private void InspectLetter()
	{
		print("inspecting");
		
		var inventory = GetComponent<Inventory>();
		if (inventory.GetInventoryItem("letter"))
		{
			var letter = inventory.GetInventoryItem("letter");
			
			print(letter.name);
			switch (letter.name)
			{
				case "LetterLevel0":
					_hints[0].gameObject.SetActive(true);
					break;
				case "LetterLevel1":
					_hints[1].gameObject.SetActive(true);
					break;
				case "LetterLevel2":
					_hints[2].gameObject.SetActive(true);
					break;
				case "LetterLevel3":
					_hints[3].gameObject.SetActive(true);
					break;
			}
		}
	}

	private void Move()
	{
		if (!_canMove) return;
		
		_movement.x = Input.GetAxisRaw("Horizontal");
		_movement.y = Input.GetAxisRaw("Vertical");

		if (isInverted) {
			_movement.x *= -1;
			_movement.y *= -1;
		}

		_rb.velocity = new Vector2(_movement.x * _speed / 2, _movement.y * _speed / 2);

		if (_movement.x != 0)
		{
			_lastDirectionX = _rb.velocity.x;
			_lastDirectionY = 0;
		}

		if (_movement.y != 0)
		{
			_lastDirectionY = _rb.velocity.y;
			_lastDirectionX = 0;
		}
	}
	
}
