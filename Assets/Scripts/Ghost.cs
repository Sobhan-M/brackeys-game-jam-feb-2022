using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
 
    [SerializeField] float deathDelay = 1f;
    [SerializeField] float secondsToDie = 3f;
    private float timeSpentBurning;
    Player player;

    SpriteRenderer spriteRenderer;

    [SerializeField] float ghostSpeed = 2f;
    Rigidbody2D rigidBody;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        timeSpentBurning = 0f;
    }

    public void GetHurt(float time)
    {
        timeSpentBurning += time;
        if (timeSpentBurning >= secondsToDie)
        {
            Die();
        }

        Fade();
    }

    private void Die()
    {
        Destroy(gameObject, deathDelay);
    }

    private void PursuePlayer()
    {
        Vector3 playerPosition = player.transform.position;
        Vector2 target = Vector2.MoveTowards(rigidBody.position, new Vector2(playerPosition.x, playerPosition.y), ghostSpeed*Time.deltaTime);
        rigidBody.MovePosition(target);
    }

    void FixedUpdate()
    {
        PursuePlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("You Lose!");
            Die();
        }
    }

    private void Fade()
    {
        Color spriteColour = spriteRenderer.color;
        spriteRenderer.color = new Color(spriteColour.r, spriteColour.g, spriteColour.b, 1.2f - (timeSpentBurning / secondsToDie));
    }



}
