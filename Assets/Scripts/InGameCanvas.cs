using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameCanvas : MonoBehaviour
{

    private void Start() {
        GetComponentsInChildren<Button>()[1].onClick.AddListener(() => {
            Restart();
        });
    }

    public void LoadMenu() {
        SceneLoader.Instance.LoadLevel("Menu");
    }

    public void Restart() {
        SceneLoader.Instance.Restart();
    }
}
