using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSpiral : GravityObject
{
    public string SceneToLoadAfterWinning = "Menu";
    [SerializeField]
    public float force = 30;

    public bool isLastInWorld = false;

    public override void ApplyGravityForce() {
        Rigidbody2D RbTpAttract = Player.Instance.Body;
        RbTpAttract.AddForce((Body.position - Player.Instance.Body.position).normalized * force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Player.Instance.gameObject == collision.attachedRigidbody.gameObject)
        {
            LeanTween.move(Player.Instance.gameObject, transform, 0.5f);
            Player.Instance.Win(SceneToLoadAfterWinning, isLastInWorld);
        }
    }
}
