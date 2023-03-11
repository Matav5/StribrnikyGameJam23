using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public abstract class GravityObject : MonoBehaviour
{
    [SerializeField]
    protected float radius = 5;

    // only for graphics tweak
    [SerializeField]
    private float graphicsSizeMult = 0.5f;

    [SerializeField]
    private SpriteRenderer radiusDisplay;

    public Rigidbody2D Body {get; private set; }

    public float Radius {
        get {
            return radius;
        }
        set {
            radius = value;
            UpdateRadius();
        }
    }
    protected virtual void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start() {
        UpdateRadius();
    }

    protected void UpdateRadius() {
        //outerRing.transform.localScale = Vector3.one * radius;
        LeanTween.scale(radiusDisplay.gameObject, Vector3.one * radius * graphicsSizeMult, 0.25f);
    }

    protected virtual void FixedUpdate() {
        if (CheckRadius()) {
            ApplyGravityForce();
        }
    }

    protected bool CheckRadius() {
        return Vector2.Distance(transform.position, Player.Instance.transform.position) < Radius;
    }

    public abstract void ApplyGravityForce();

    public void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, Vector3.one * radius);
    }
}
