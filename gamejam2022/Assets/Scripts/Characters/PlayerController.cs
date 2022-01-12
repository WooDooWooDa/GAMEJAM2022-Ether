using System;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float _speed = 10f;
	[SerializeField] private Animator _animator;
	[SerializeField] private Rigidbody2D _rb;
	[SerializeField] private GameObject _cameraPrefab;

	private bool _canInteractWithMenu = false;
	private bool _isMoving;
	private bool _canMove = true;
	private Vector2 _movement;
	private float _lastDirectionX; 
	private float _lastDirectionY;
	private GameObject _dialogue;

	//private float[,] _menuInteractionsPos => new float[,] {{206.1f, 111.5f}, {206.1f, 85.4f}};
	
	private string RandomString(int length)
	{
		var random = new Random();
		const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		return new string(Enumerable.Repeat(chars, length)
			.Select(s => s[random.Next(s.Length)]).ToArray());
	}

	private void Awake()
	{
		_dialogue = GameObject.FindWithTag("Dialogue");
		_dialogue.gameObject.SetActive(false);
	}

	private void Start()
	{
		var cameraInstance = Instantiate(_cameraPrefab);
		cameraInstance.GetComponent<CameraControl>().target = gameObject;
	}

	private void Update()
	{
		_animator.SetFloat("VelocityX", _movement.x);
		_animator.SetFloat("VelocityY", _movement.y);
		_animator.SetBool("IsMoving", _isMoving);
		
		_isMoving = _rb.velocity.x != 0 || _rb.velocity.y != 0;
		_animator.SetBool("IsMoving", _isMoving);
		_animator.SetFloat("LastDirectionX", _lastDirectionX);
		_animator.SetFloat("LastDirectionY", _lastDirectionY);

		ShowDialogue();
		ChangeDialogue();
		InteractWithMenu();
	}

	private void InteractWithMenu()
	{
		if (!_canInteractWithMenu) return;

		if (Input.GetKeyDown(KeyCode.X))
		{
			
		}
	}

	private void ChangeDialogue()
	{
		if (!Input.GetKeyDown(KeyCode.F)) return;
		if (_dialogue.activeSelf)
		{
			_dialogue.GetComponentInChildren<DialogueScript>().SetDialogueText(RandomString(32));
		}
	}

	private void ShowDialogue()
	{
		if (!Input.GetKeyDown(KeyCode.R)) return;
		_dialogue.gameObject.SetActive(!_dialogue.gameObject.activeSelf);
		TogglePlayerMovement();
	}

	private void FixedUpdate()
	{
		Move();
	}

	private void Move()
	{
		if (!_canMove) return;
		
		_movement.x = Input.GetAxisRaw("Horizontal");
		_movement.y = Input.GetAxisRaw("Vertical");

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

	private void TogglePlayerMovement()
	{
		_canMove = !_canMove;
		_canInteractWithMenu = !_canInteractWithMenu;
	}
}
