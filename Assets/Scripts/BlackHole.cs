using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BlackHole : GravityObject, IInteractable
{
    [SerializeField]
    public float force = 100;
    [SerializeField]
    private float radius = 5;


    private float normalRadius;
    [SerializeField]
    private float increasedRadius = 5;
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
    void Start()
    {
        SetRadius();
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, Player.Instance.transform.position) < Radius)
        {

            Rigidbody2D RbTpAttract = Player.Instance.Body;

            RbTpAttract.AddForce((Body.position - Player.Instance.Body.position).normalized * force);

        }
    }
   
    public void OnButtonDown()
    {
        normalRadius = Radius;
        Radius = increasedRadius;
    }

    public void OnButtonUp()
    {
        Radius = normalRadius;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.GameOver();
        }
    }
}
