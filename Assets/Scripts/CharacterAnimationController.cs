using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private const string ROTATION = "AngularVelocity";
    private const string SAD = "Sad";
    private const string SATISFIED= "Satisfied";
    private const string HAPPY = "Happy";
    private const string SURPRISED= "Surprised";

    private Animator animator;
    private Rigidbody2D body;
    [SerializeField]
    private SpriteRenderer circleRenderer;


    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        body = GetComponent<Rigidbody2D>();
        circleRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        animator.SetFloat(ROTATION, body.angularVelocity);
    }

    public void PlaySad() {
        animator.SetTrigger(SAD);
    }
    public void PlaySatisfied() {
        animator.SetTrigger(SATISFIED);
    }
    public void PlayHappy() {
        animator.SetTrigger(HAPPY);
    }
    public void PlaySurprised() {
        animator.SetTrigger(SURPRISED);
    }
}
