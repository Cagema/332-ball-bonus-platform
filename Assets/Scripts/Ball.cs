using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ball : MonoBehaviour
{
	[SerializeField] float _force;
	[SerializeField] float _randomForce;
    Rigidbody2D _rb;
	Bonus _bonus;
	private void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (GameManager.Single.GameActive)
		{
			if (transform.position.y < -GameManager.Single.RightUpperCorner.y - 1)
			{
				Destroy(gameObject);
				GameManager.Single.LostLive();
			}
		}
	}

	public void StartFall()
    {
		_rb.gravityScale = 1;
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Platform"))
		{
			_rb.velocity = Vector2.zero;
			Vector2 dir = transform.position - collision.transform.position;
			dir = new Vector2(dir.x + Random.Range(-_randomForce, _randomForce), dir.y);
			_rb.AddForce(dir.normalized * _force, ForceMode2D.Impulse);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Bonus"))
		{
			GameManager.Single.Score ++;
			if (_bonus == null) _bonus = collision.GetComponent<Bonus>();
			_bonus.SetNewPos();

			//_rb.velocity = Vector2.zero;
			//Vector2 dir = Random.insideUnitCircle;
			//_rb.AddForce(dir.normalized * _force, ForceMode2D.Impulse);
		}
	}
}
