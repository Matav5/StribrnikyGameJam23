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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.GameOver(CauseOfDeath.CrushedByAsteroid);
        }
    }
}
