using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.attachedRigidbody != null && collision.attachedRigidbody.GetComponent<Asteroid>())
        {
            Destroy(collision.attachedRigidbody.gameObject);
        }
    }
}
