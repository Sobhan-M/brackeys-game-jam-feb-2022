using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<GameObject> thingsToSpawn;
    private bool hasActivated = false;

    [SerializeField] AudioClip ghostNoises;

    private void Start()
    {
        foreach (GameObject thing in thingsToSpawn)
        {
            thing.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !hasActivated)
        {
            AudioSource.PlayClipAtPoint(ghostNoises, FindObjectOfType<Player>().gameObject.transform.position, 3f);
            hasActivated = true;
            foreach (GameObject thing in thingsToSpawn)
            {
                thing.SetActive(true);
            }
        }
    }
}
