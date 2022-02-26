using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    [SerializeField] Canvas interactCanvas;
    [SerializeField] GameObject lightSource;

    private bool canInteract = false;

    private void Start()
    {
        interactCanvas.gameObject.SetActive(false);
        lightSource.SetActive(false);
    }

    private void InteractWithCandle()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            lightSource.SetActive(!lightSource.activeSelf);
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Ghost ghost = collision.GetComponent<Ghost>();
            ghost.GetHurt(Time.deltaTime);
        }
    }

    private void Update()
    {
        InteractWithCandle();
    }
}
