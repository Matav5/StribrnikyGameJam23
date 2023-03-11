using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSpiral : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Player.Instance.gameObject == collision.attachedRigidbody.gameObject)
        {
            Player.Win();
        }
    }
}
