using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BlackHole : GravityObject, IInteractable
{
    [SerializeField]
    public float pullForce = 5;
    private float defPullForce;
    private float normalRadius;
    [SerializeField]
    private float increasedRadius = 5;
    [SerializeField]
    private float increasedPullForce = 10;
    [SerializeField]
    private Transform wavePrefab;

    bool isActivated = false;
    [SerializeField]
    private float visualWavesCooldown = 1;

    protected override void Start() {
        base.Start();
        StartCoroutine(ShowPull());
    }

    private IEnumerator ShowPull() {
        while (true) {
            yield return new WaitForSeconds(isActivated ? visualWavesCooldown : visualWavesCooldown * 2);
            var wave = Instantiate(wavePrefab, transform);
            if(isActivated)
                wave.localScale *= increasedRadius / radius;
            wave.localScale *= 0.7f;
            LeanTween.rotateZ(wave.gameObject, UnityEngine.Random.Range(-700,700), visualWavesCooldown * 2);
            LeanTween.scale(wave.gameObject, Vector3.zero, visualWavesCooldown*2).setDestroyOnComplete(true);
        }
    }

    public override void ApplyGravityForce() {
        Rigidbody2D RbTpAttract = Player.Instance.Body;
        RbTpAttract.AddForce((Body.position - Player.Instance.Body.position).normalized * pullForce);
    }

    public void OnButtonDown()
    {
        normalRadius = Radius;
        Radius = increasedRadius;
        isActivated = true;
        defPullForce = pullForce;
        pullForce = increasedPullForce;
    }

    public void OnButtonUp()
    {
        Radius = normalRadius;
        isActivated = false;
        pullForce = defPullForce;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.GameOver();
        }
    }
}
