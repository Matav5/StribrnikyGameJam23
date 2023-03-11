using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParentalRotator : MonoBehaviour
{
    [SerializeField]
    private List<RotationSpeed> objects;

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
    public Vector3 axis;
    public float speed;
    public void ApplyRotation() {
        objectToRotate.Rotate(axis * speed * Time.deltaTime);
    }
}
