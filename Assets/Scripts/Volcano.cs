using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Volcano : MonoBehaviour
{
    public float Force = 100;
    public bool RemoveAtUsage = true;
    public Transform Pivot;
    
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
            Destroy(gameObject);
        }
    }
}
