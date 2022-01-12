using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAI : MonoBehaviour
{
	[SerializeField] private Animator _animator;
	[SerializeField] private Rigidbody2D _rb;
	[SerializeField] private float _speed = 2.5f;
	
	private bool _isReadyToDecide = true; 
	private bool _isMoving;
	private float _lastDirectionX; 
	private float _lastDirectionY;
	private Vector2 _movement;
	
	private void Start()
	{
		StartCoroutine(DecideWhereToGo());
	}

    private void Update()
    {
	    _animator.SetFloat("VelocityX", _movement.x);
	    _animator.SetFloat("VelocityY", _movement.y);
	    _animator.SetBool("IsMoving", _isMoving);
	    _isMoving = _rb.velocity.x != 0 || _rb.velocity.y != 0;
	    _animator.SetFloat("LastDirectionX", _lastDirectionX);
	    _animator.SetFloat("LastDirectionY", _lastDirectionY);
    }

    private IEnumerator DecideWhereToGo()
    {
	    while (true)
	    {
		    yield return new WaitForSeconds(Random.Range(0f, 4f));
		    Move(ChooseRandomDirection(), ChooseRandomDirection());

		    yield return new WaitForSeconds(1);
		    Move(0, 0);
	    }
    }

    private int ChooseRandomDirection()
    {
	    var rdmNumber = Random.Range(0, 100);

	    if (rdmNumber > 60)
	    {
		    return 1;
	    }
	    
	    if (rdmNumber < 40)
	    {
		    return -1;
	    }
	    
	    if (rdmNumber < 60 && rdmNumber > 40)
	    {
		    return 0;
	    }

	    return 0;
    }
    
    private void Move(float x, float y)
    {
	    _movement.x = x;
	    _movement.y = y;
	    _rb.velocity = new Vector2(x * _speed / 2, y * _speed / 2);

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