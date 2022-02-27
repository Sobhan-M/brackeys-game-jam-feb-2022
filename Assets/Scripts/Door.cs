using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Canvas interactCanvas;
    private Collider2D doorCollider;
    private Animator animator;

    private bool canInteract = false;
    private bool isOpen = false;

    [SerializeField] AudioClip openingSound;
    [SerializeField] AudioClip closingSound;

    private void Awake()
    {
        doorCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        doorCollider.enabled = true;
        interactCanvas.gameObject.SetActive(false);
    }

    private void InteractWithDoor()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            doorCollider.enabled = !doorCollider.enabled;
            
            isOpen = !isOpen;
            animator.SetBool("IsOpen", isOpen);

            if (isOpen)
            {
                AudioSource.PlayClipAtPoint(openingSound, transform.position, 10f);
            }
            else
            {
                AudioSource.PlayClipAtPoint(closingSound, transform.position, 10f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canInteract = true;
            interactCanvas.gameObject.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canInteract = false;
            interactCanvas.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        InteractWithDoor();
    }


}
