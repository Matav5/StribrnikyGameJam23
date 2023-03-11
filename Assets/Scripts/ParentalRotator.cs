using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ParentalRotator : MonoBehaviour
{
    [Header("Full auto for all children")]
    [SerializeField]
    private float SpeedForAll = 10;

    [Header("Range is -SpeedForAll to +SpeedForAll")]
    public bool RandomSpeed = true; 

    [Header("Setup objects manually")]
    public bool SetupObjectsManually = false;
    [SerializeField]
    private List<RotationSpeed> objects;

    private void Start() {
        if (!SetupObjectsManually) {
            var all = GetComponentsInChildren<SpriteRenderer>();
            objects = new List<RotationSpeed>();
            for (int i = 0; i < all.Length; i++) {
                objects.Add(new RotationSpeed() {
                    objectToRotate = all[i].transform,
                    speed = RandomSpeed ? UnityEngine.Random.Range(-SpeedForAll, SpeedForAll) : SpeedForAll
                });
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var obj in objects) {
            obj.ApplyRotation();
        }
    }
}

[Serializable]
public class RotationSpeed
{
    public Transform objectToRotate;
    public Vector3 axis = Vector3.forward;
    public float speed;
    public void ApplyRotation() {
        objectToRotate.Rotate(axis * speed * Time.deltaTime);
    }
}
