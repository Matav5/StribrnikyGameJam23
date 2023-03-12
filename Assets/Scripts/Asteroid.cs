using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D body;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
    }
    public void Push(System.Random rnd, Vector2Int asteroidPush)
    {
        body.AddForce(transform.up * rnd.Next(asteroidPush.x, asteroidPush.y));

    }
}
