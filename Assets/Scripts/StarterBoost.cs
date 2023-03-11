using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterBoost : MonoBehaviour
{
    public Transform directionPoint;
    public float force = 100;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Player.Instance.gameObject == collision.attachedRigidbody.gameObject)
        {
            Vector2 dir = directionPoint.position - transform.position;
            Player.Instance.Body.AddForce(dir * force);
        }
    }
}