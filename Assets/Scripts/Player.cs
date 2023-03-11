
using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Player : SceneSingleton<Player>
{
    private Rigidbody2D body;
    public Rigidbody2D Body => body;
    public CinemachineVirtualCamera PlayerCamera;
    public Volcano Volcano;
    protected override void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Vector2 dir = Map.Instance.StarterBoost.directionPoint.position - transform.position;
        Body.AddForce(dir.normalized * 100);
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
                else
                {
                    if (Volcano != null)
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

    public void Win() {
    }

    internal void GameOver() {
        SceneLoader.Instance.Restart();
    }
}

