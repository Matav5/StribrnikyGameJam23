using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Star : GravityObject, IInteractable
{
    [SerializeField]
    public float pullForce = 5;
    [SerializeField]
    public float pulseForce = 100;

    [SerializeField]
    private Transform wavePrefab;
    [SerializeField]
    private Transform graphicsRef;

    public override void ApplyGravityForce() {
        Player.Instance.Body.AddForce((Body.position - Player.Instance.Body.position).normalized * pullForce);
        Player.Instance.Animator.PlayHappy();
    }

    public void OnButtonDown()
    {
        EmitWave();

        if (CheckRadius())
        {
            Rigidbody2D RbTpAttract = Player.Instance.Body;
            RbTpAttract.AddForce((Player.Instance.Body.position - Body.position).normalized * pulseForce);
        }
    }

    private void EmitWave() {
        var wave = Instantiate(wavePrefab, transform.position, Quaternion.identity);
        LeanTween.color(wave.gameObject, new Color(1f,1f,1f,0f), 0.12f).setDelay(0.04f).setDestroyOnComplete(true);
        LeanTween.scale(wave.gameObject, Vector3.one * 6f, 0.15f);
    }

    public void OnButtonUp()
    {
        //Nic
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.GameOver(CauseOfDeath.CrushedByStar);
        }
    }


}
