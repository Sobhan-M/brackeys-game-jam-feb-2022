using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] float radiusFromPlayer = 2f;
    private Player player;
    private Camera mainCamera;
    
    
    void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    void Start()
    {
        transform.position = player.transform.position + new Vector3(radiusFromPlayer, 0, 0);

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
        transform.rotation = Quaternion.AngleAxis(angleInDeg, Vector3.forward);
        // Move torch along the unit circle.
        transform.localPosition = radiusFromPlayer * (new Vector3(Mathf.Cos(angleInRad), Mathf.Sin(angleInRad), 0));
    }

    void Update()
    {
        Rotate();
    }

}
