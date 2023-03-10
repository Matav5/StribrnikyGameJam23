using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class GravityObject : MonoBehaviour
{
    public Rigidbody2D Body {get; private set;}
    private void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
    }
}
