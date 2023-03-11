using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Star : GravityObject, IInteractable
{
    [SerializeField]
    public float pullForce = 5;
    [SerializeField]
    public float pulseForce = 100;
    [SerializeField]
    private float radius = 5;
    [SerializeField]
    private SpriteRenderer outerRing;
    public float Radius
    {
        get
        {
            return radius;
        }
        set
        {
            radius = value;
            SetRadius();
        }
    }
    private void SetRadius()
    {
        outerRing.transform.localScale = Vector3.one * radius;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetRadius();
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, Player.Instance.transform.position) < Radius)
        {
            
            Rigidbody2D RbTpAttract = Player.Instance.Body;

            RbTpAttract.AddForce((Body.position - Player.Instance.Body.position).normalized * pullForce);
             
        }
    }

    public void OnButtonDown()
    {
        if (Vector2.Distance(transform.position, Player.Instance.transform.position) < Radius)
        {
            Rigidbody2D RbTpAttract = Player.Instance.Body;

            RbTpAttract.AddForce((Player.Instance.Body.position - Body.position).normalized * pulseForce);
        }
    }

    public void OnButtonUp()
    {
        //Nic
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.GameOver();
        }
    }
}
