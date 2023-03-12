using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundFeeder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var scene = SceneManager.GetActiveScene();
        if(int.TryParse(scene.name[5].ToString(), out int wrld)) {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("background" + (wrld + 1));
        }

    }
}
