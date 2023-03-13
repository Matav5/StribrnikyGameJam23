using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelItem : MonoBehaviour
{
    private const string LAST_FINISHED_WORLD = "LastWonWorld";
    private const string LAST_FINISHED_PIECE = "LastWonPiece";

    public int worldKey = 0;
    [SerializeField]
    private List<Image> levelImages;

    [SerializeField]
    private Button playButton;

    [SerializeField]
    private List<Image> achievementImages;

    [SerializeField]
    private Color doneColor;
    [SerializeField]
    private Color currentColor;
    [SerializeField]
    private Color notDoneColor;

    // Start is called before the first frame update
    void Start()
    {
        int lastFinished = PlayerPrefs.GetInt(LAST_FINISHED_WORLD, -1);
        if(worldKey > lastFinished+1) {
            LockWorld();
        } else {
            UnlockWorld();
        }
        ShowAchievements();
        ShowDoneParts();
        
    }

    private void LockWorld() {
        playButton.interactable = false;
        playButton.GetComponentInChildren<TMP_Text>().text = "---";
    }

    private void UnlockWorld() {
        playButton.interactable = true;
        playButton.GetComponentInChildren<TMP_Text>().text = "Play";
        playButton.onClick.AddListener(() => {
            AchievementHolder.Instance.StartWorld(worldKey);
            SceneLoader.Instance.LoadLevel("World"+worldKey+"_Level0");
        });
    }

    private void ShowAchievements() {
        achievementImages[0].color = AchievementHolder.Instance.IsAchieved(Achievement.Done, worldKey) ? doneColor : currentColor; 
        achievementImages[1].color = AchievementHolder.Instance.IsAchieved(Achievement.Star, worldKey) ? doneColor : currentColor;
        achievementImages[2].color = AchievementHolder.Instance.IsAchieved(Achievement.FirstTake, worldKey) ? doneColor : currentColor;
    }

    private void ShowDoneParts() {
        int lastFinishedPiece = PlayerPrefs.GetInt(LAST_FINISHED_PIECE+worldKey, -1);

        for (int i = 0; i < levelImages.Count; i++) {
            Image levelImage = levelImages[i];
            if(i < lastFinishedPiece) {
                levelImage.color = doneColor;
            } else if (i == lastFinishedPiece) {
                levelImage.color = currentColor;
            } else {
                levelImage.color = notDoneColor;
            }

        }
    }
}
