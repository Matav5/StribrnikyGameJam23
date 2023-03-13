using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nebula : MonoBehaviour
{
    [SerializeField]
    [Range(0,3)]
    private float slowDrag = 2;
    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.attachedRigidbody != null)
            if (collision.attachedRigidbody.gameObject == Player.Instance.gameObject)
            {
                Player.Instance.SlowDrag(slowDrag);
            }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody != null)
            if (collision.attachedRigidbody.gameObject == Player.Instance.gameObject)
            {
                Player.Instance.ResetDrag();
            }
    }
}
