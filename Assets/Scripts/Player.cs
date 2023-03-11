
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : SceneSingleton<Player>
{
    private Rigidbody2D body;
    public Rigidbody2D Body => body;

    protected override void Awake()
    {
        body = GetComponent<Rigidbody2D>();
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
                IInteractable interactable = hit.rigidbody.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.OnButtonDown();
                    StartCoroutine(Wait(interactable));
                }
            }
        }
    }
    public IEnumerator Wait(IInteractable hit)
    {
        while (Input.GetMouseButton(0))
        {
            yield return new WaitForEndOfFrame();
        }
        hit.OnButtonUp();
    }
}

