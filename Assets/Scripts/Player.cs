
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : SceneSingleton<Player>
{
    public Rigidbody2D Body;
    public Volcano Volcano;
    protected override void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
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
                else
                {
                    if(Volcano!= null)
                        Volcano.StartFiring();
                }
            }
            else
            {
                if (Volcano != null)
                    Volcano.StartFiring();
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

    internal void GameOver()
    {
        Debug.Log("You lost zulul");
    }

    internal static void Win()
    {
        Debug.Log("You won zulul");
    }
}

