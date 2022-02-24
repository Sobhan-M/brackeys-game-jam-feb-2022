using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Canvas interactCanvas;
    private Collider2D doorCollider;
    private SpriteRenderer doorSpriteRenderer;

    private bool canInteract = false;

    private void Awake()
    {
        doorCollider = GetComponent<CapsuleCollider2D>();
        doorSpriteRenderer = GetComponent<SpriteRenderer>();
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
            Color doorColour = doorSpriteRenderer.color;
            doorCollider.enabled = !doorCollider.enabled;
            doorSpriteRenderer.color = new Color(doorColour.r, doorColour.g, doorColour.b, doorColour.a < 0.7f ? 1f : 0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DisplayInteract();
        canInteract = true;
        interactCanvas.gameObject.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        RemoveInteract();
        canInteract = false;
        interactCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        InteractWithDoor();
    }


}
