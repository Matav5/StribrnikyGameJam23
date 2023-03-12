
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Volcano : MonoBehaviour
{
    public float Force = 100;
    public bool RemoveAtUsage = true;
    public Transform Pivot;

    public Sprite destroyedSprite;
    public List<Rigidbody2D> partTypes = new List<Rigidbody2D>();
    public float partsEnergy = 100;

    public void StartFiring()
    {
        StartCoroutine(Fire());
      
    }
    public IEnumerator Fire()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        while (Input.GetMouseButton(0))
        {
            mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 lookDir = transform.position - mouse;
            lookDir.y = 0;
            if (mouse != transform.position)
            {
                Vector3 lookPos = mouse - Pivot.position;
                float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
                Pivot.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            };
            yield return new WaitForEndOfFrame();
        }
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Player.Instance.Body.AddForce((Player.Instance.Body.position  - new Vector2(mouse.x, mouse.y)).normalized * Force);
        if (RemoveAtUsage)
        {
            Pop();
        }
    }

    private void Pop() {
        GetComponentInChildren<SpriteRenderer>().sprite = destroyedSprite;
        CreateParts(5);
    }

    private void CreateParts(int count) {
        for (int i = 0; i < count; i++) {
            var stone = Instantiate(partTypes[UnityEngine.Random.Range(0, partTypes.Count)], transform.position, Quaternion.identity);
            var dir = Pivot.position - transform.position;
            dir.x *= Random.Range(0.9f, 0.9f);
            dir.y *= Random.Range(0.9f, 0.9f);
            stone.AddForce((dir) * partsEnergy);
            LeanTween.rotateZ(stone.gameObject, UnityEngine.Random.Range(-50, 50), 0.3f);
            Destroy(stone, 0.3f);
        }
    }
}
