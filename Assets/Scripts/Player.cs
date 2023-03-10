
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : SceneSingleton<Player>
{
    public Rigidbody2D Body;
    protected override void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        
    }
    private void FixedUpdate()
    {

    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                hit.rigidbody.GetComponent<IInteractable>()?.Click();
            }
        }
    }
}

