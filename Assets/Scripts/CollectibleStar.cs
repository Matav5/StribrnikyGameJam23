using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleStar : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.attachedRigidbody == Player.Instance.Body) {
            AchievementHolder.Instance.StarCollected();
            Destroy(gameObject);
        }
    }
}
