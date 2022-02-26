using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    //[SerializeField] float radiusFromPlayer = 0.5f;
    private Player player;
    private Camera mainCamera;
    private Rigidbody2D rigidBody;
    
    
    void Awake()
    {
        player = FindObjectOfType<Player>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        //transform.position = player.transform.position + new Vector3(radiusFromPlayer, 0, 0);

        mainCamera = Camera.main;
    }

    private void Rotate()
    {
        // Find angle.
        Vector3 mouse = Input.mousePosition;
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(player.transform.position);
        float angleInRad = Mathf.Atan2(mouse.y - screenPosition.y, mouse.x - screenPosition.x);
        float angleInDeg = angleInRad * Mathf.Rad2Deg;

        // Rotate the torch.
        rigidBody.MoveRotation(angleInDeg);
    }

    void Update()
    {
        Rotate();
    }
}
