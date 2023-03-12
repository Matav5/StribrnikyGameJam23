using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : SceneSingleton<Player>
{
    private Rigidbody2D body;
    public Rigidbody2D Body => body;
    public CinemachineVirtualCamera PlayerCamera;
    public Volcano Volcano;
    private CharacterAnimationController characterAnimationController;
    public CharacterAnimationController Animator => characterAnimationController;

    public bool IsVolcanoAllowed;

   
    protected override void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        characterAnimationController = GetComponent<CharacterAnimationController>();
        if (!IsVolcanoAllowed)
            Volcano = null;
    }
    private void Start()
    {
        Vector2 dir = Map.Instance.StarterBoost.directionPoint.position - transform.position;
        Body.AddForce(dir.normalized * 100);

        characterAnimationController.PlaySad();
    }
    private void FixedUpdate()
    {

    }
    public void Update() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit && hit.rigidbody) {
                IInteractable interactable = hit.rigidbody.GetComponent<IInteractable>();
                if (interactable != null) {
                    interactable.OnButtonDown();
                    StartCoroutine(Wait(interactable));
                } else {

                    if (Volcano != null)
                        Volcano.StartFiring();
                }
            } else {
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

    public void Win(string scene) {

        Body.constraints = RigidbodyConstraints2D.FreezePosition;
        Body.AddTorque(50);
        LeanTween.scale(gameObject, Vector3.zero, 1.45f);
        characterAnimationController.PlaySatisfied();
        SceneLoader.Instance.LoadLevel(scene);
    }

    internal void GameOver(CauseOfDeath causeOfDeath = CauseOfDeath.NotSpecified) {

        LeanTween.scale(gameObject, Vector3.zero, 1.45f);
        SceneLoader.Instance.Restart();
    }
    public void SlowDrag(float slowDrag)
    {
        body.drag = slowDrag;
    }
    public void ResetDrag()
    {
        body.drag = 0;
    }
}


public enum CauseOfDeath
{
    NotSpecified,
    LostInDarkMatter,
    PulledByBlackHole,
    CrushedByStar,
    CrushedByPlanet,
    CrushedByAsteroid,
    StuckInNebula
}
