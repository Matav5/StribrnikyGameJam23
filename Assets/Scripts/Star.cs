using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Star : GravityObject, IInteractable
{
    [SerializeField]
    public float Force;
    [SerializeField]
    public float Radius;
    // Start is called before the first frame update
    void Start()
    {
        
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
        
        Gizmos.DrawSphere(transform.position, Radius);
    }

    public void Click()
    {
        Debug.Log("clikc");
        if (Vector2.Distance(transform.position, Player.Instance.transform.position) < Radius)
        {
            Rigidbody2D RbTpAttract = Player.Instance.Body;

            RbTpAttract.AddForce((Player.Instance.Body.position - Body.position).normalized * 100);
        }
    }
}
