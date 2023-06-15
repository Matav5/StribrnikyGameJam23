using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class LevelButton : MonoBehaviour
{
    [SerializeField]
    private TMP_Text numberText;

    private Button button;
    private Button Button {
        get {
            if (button == null)
                button = GetComponent<Button>();
            return button;
        }
    }

    [SerializeField]
    private Image planetImage;

    private int world;
    private int number;

    public void SetWorldAndNumber(int world, int number) {
        this.world = world;
        this.number = number;

        numberText.text = (number+1).ToString();

        this.Button.onClick.AddListener(() => {
            AchievementHolder.Instance.StartWorld(world);
            SceneLoader.Instance.LoadLevel($"World{world}_Level{number}");
        });
    }

    public void SetDone() {
        planetImage.gameObject.SetActive(true);
        Button.interactable = true;
    }

    internal void SetLocked() {
        Button.interactable = false;
        planetImage.gameObject.SetActive(false);
    }

    internal void SetCurrent() {
        Button.interactable = true;
        planetImage.gameObject.SetActive(false);
    }
}
