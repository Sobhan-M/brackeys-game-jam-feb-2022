using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1f;
	private Rigidbody2D rigidBody;
	private GameObject torch;

	void Awake()
    {
		rigidBody = GetComponent<Rigidbody2D>();
		torch = FindObjectOfType<Torch>().gameObject;
    }

	private void Move()
	{
		rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigidBody.velocity.y);
        // Vector2 velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigidBody.velocity.y);
        // rigidBody.MovePosition(rigidBody.position + velocity * Time.fixedDeltaTime);
        FlipCharacter();
	}

	private void FlipCharacter()
    {
		if (Input.GetAxis("Horizontal") < 0)
        {
			transform.localScale = new Vector3(-1, 1, 1);
			torch.transform.localScale = new Vector3(-Mathf.Abs(torch.transform.localScale.x), torch.transform.localScale.y, torch.transform.localScale.z);
        }
		else if (Input.GetAxis("Horizontal") > 0)
        {
			transform.localScale = new Vector3(1, 1, 1);
			torch.transform.localScale = new Vector3(Mathf.Abs(torch.transform.localScale.x), torch.transform.localScale.y, torch.transform.localScale.z);
		}
    }

	void FixedUpdate()
    {
		Move();
    }
}
