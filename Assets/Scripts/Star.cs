using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Star : GravityObject, IInteractable
{
    [SerializeField]
    public float force = 100;
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

    // Update is called once per frame
    void Update()
    {
      
    }
    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, Player.Instance.transform.position) < Radius)
        {
            
            Rigidbody2D RbTpAttract = Player.Instance.Body;

            RbTpAttract.AddForce((Body.position - Player.Instance.Body.position).normalized);
             
        }
    }

    private void OnDrawGizmos()
    {   
        Gizmos.color= Color.green;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }

  

    public void OnButtonDown()
    {
        Debug.Log("clikc");
        if (Vector2.Distance(transform.position, Player.Instance.transform.position) < Radius)
        {
            Rigidbody2D RbTpAttract = Player.Instance.Body;

            RbTpAttract.AddForce((Player.Instance.Body.position - Body.position).normalized * force);
        }
    }

    public void OnButtonUp()
    {
    }
}
