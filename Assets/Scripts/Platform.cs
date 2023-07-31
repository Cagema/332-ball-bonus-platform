using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
	[SerializeField] float _speed;
    Vector2 _mousePos;
	Vector2 _finish;
    private void Start()
    {
		_finish = transform.position;
    }

    private void Update()
	{
		if (GameManager.Single.GameActive)
		{
			if (Input.GetMouseButton(0))
			{
				_mousePos = GameManager.Single.MainCamera.ScreenToWorldPoint(Input.mousePosition);
				_finish = new Vector3(_mousePos.x, transform.position.y, transform.position.z);
			}

			transform.position = Vector3.MoveTowards(transform.position, _finish, Time.deltaTime * _speed);
		}
	}
}
