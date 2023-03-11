
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wormhole : MonoBehaviour
{
    public Transform portal1;
    public Transform portal2;

    private Transform previouslyUsedPortal;
    private bool skipTriggerExit = false;
    private void Awake()
    {
        
    }
    public void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (previouslyUsedPortal)
            return;

        if(Player.Instance.Body == collision.attachedRigidbody)
        {
            if (Vector2.Distance(portal1.position, Player.Instance.transform.position) < Vector2.Distance(portal2.position, Player.Instance.transform.position))
            {
                Player.Instance.Body.MovePosition(portal2.position);
                previouslyUsedPortal = portal2;
            }
            else
            {
                Player.Instance.Body.MovePosition(portal1.position);
                previouslyUsedPortal = portal1;
            }
            skipTriggerExit = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (skipTriggerExit)
        {
            skipTriggerExit = false;
            return;
        }
        previouslyUsedPortal = null;
    }
}
