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
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canInteract = true;
        interactCanvas.gameObject.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canInteract = false;
        interactCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        InteractWithDoor();
    }


}
