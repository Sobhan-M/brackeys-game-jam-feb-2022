using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1f;
	private Rigidbody2D rigidBody;
	private GameObject torch;
	private Animator animator;

	[SerializeField] int playerHealth = 3;
	[SerializeField] float dieDelay = 2f;
	[SerializeField] Slider healthBar;

	AudioSource walkingSound;

	void Awake()
    {
		rigidBody = GetComponent<Rigidbody2D>();
		torch = FindObjectOfType<Torch>().gameObject;
		animator = GetComponent<Animator>();
		walkingSound = GetComponent<AudioSource>();
    }

    private void Start()
    {
		healthBar.value = playerHealth;
    }

    private void Move()
	{
		rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigidBody.velocity.y);
        // Vector2 velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigidBody.velocity.y);
        // rigidBody.MovePosition(rigidBody.position + velocity * Time.fixedDeltaTime);
        FlipCharacter();

		if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
			animator.SetBool("IsWalking", true);
			if (! walkingSound.isPlaying)
            {
				walkingSound.Play();
            }

		}
		else
        {
			animator.SetBool("IsWalking", false);
			walkingSound.Stop();
		}
	}

	public void GetHurt()
    {
		--playerHealth;
		healthBar.value = playerHealth;
		if (playerHealth <= 0)
        {
			Invoke("Die", dieDelay);
        }
    }

	public void Die()
    {
		FindObjectOfType<GameManager>().LoadLose();
    }

	private void FlipCharacter()
    {
		
		if (Input.GetAxis("Horizontal") < 0)
        {
			gameObject.GetComponent<SpriteRenderer>().flipX = true;
			//transform.localScale = new Vector3(-1, 1, 1);
			//torch.transform.localScale = new Vector3(-Mathf.Abs(torch.transform.localScale.x), torch.transform.localScale.y, torch.transform.localScale.z);
        }
		else if (Input.GetAxis("Horizontal") > 0)
        {
			gameObject.GetComponent<SpriteRenderer>().flipX = false;
			//transform.localScale = new Vector3(1, 1, 1);
			//torch.transform.localScale = new Vector3(Mathf.Abs(torch.transform.localScale.x), torch.transform.localScale.y, torch.transform.localScale.z);
		}
	}

	void FixedUpdate()
    {
		Move();
    }
}
