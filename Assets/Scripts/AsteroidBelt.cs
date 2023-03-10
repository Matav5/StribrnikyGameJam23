using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
public class AsteroidBelt : MonoBehaviour
{
    public int Seed = 0;

    private Random rnd;

    public Transform spawn;
    public Transform Belt;
    public Vector2Int Interval;
    public List<Asteroid> asteroidPrefabs;
    public Vector2Int asteroidPush;
    public float Range => Belt.localScale.x;
    private void Awake()
    {
        rnd = new Random(Seed);
        StartCoroutine(StartSpawning());
    }
    public IEnumerator StartSpawning()
    {
        while (true)
        {
            SpawnAsteroid();
            yield return new WaitForSeconds(rnd.Next(Interval.x, Interval.y));
        }
    }

    private void SpawnAsteroid()
    {
        Vector2 pos = spawn.position + spawn.right * (rnd.Next(-50, 50) * Range / 100);
        var gmb = Instantiate(asteroidPrefabs.Random(), pos, Quaternion.identity, transform);
        gmb.transform.localEulerAngles = new Vector3(0, 0, -180);
        gmb.Push(rnd, asteroidPush);
    }

    private void OnDrawGizmos()
    {
        if(spawn)
        Gizmos.DrawLine(spawn.position - transform.right * Range, spawn.position + transform.right * Range);   
    }


}
