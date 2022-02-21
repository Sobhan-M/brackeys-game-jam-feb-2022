using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1f;
	private Rigidbody2D rigidBody;

	void Awake()
    {
		rigidBody = GetComponent<Rigidbody2D>();
    }

	private void Move()
	{
		Vector2 velocity = new Vector2(Input.GetAxis("Horizontal")*speed, 0);
		rigidBody.MovePosition(rigidBody.position + velocity * Time.fixedDeltaTime);
	}

	void FixedUpdate()
    {
		Move();
    }
}
