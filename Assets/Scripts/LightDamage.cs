using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDamage : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Ghost ghost = collision.GetComponent<Ghost>();
            ghost.GetHurt(Time.deltaTime);
        }
    }
}