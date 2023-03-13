using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCanvas : MonoBehaviour
{

    public void LoadMenu() {
        SceneLoader.Instance.LoadLevel("Menu");
    }
}
