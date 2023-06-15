using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelItem : MonoBehaviour
{
    private const string LAST_FINISHED_WORLD = "LastWonWorld";
    private const string LAST_FINISHED_PIECE = "LastWonPiece";

    [SerializeField]
    private LevelButton levelButtonPrefab;

    [SerializeField]
    private RectTransform levelsParent;
    [SerializeField]
    private TMP_Text worldText;
    [SerializeField]
    private Image worldBackground;
    [SerializeField]
    private Sprite worldBackgroundSprite;

    public int worldKey = 0;
    [SerializeField]
    private List<LevelButton> levelButtons;

    [SerializeField]
    private List<Image> achievementImages;

    [SerializeField]
    private Color doneColor;
    [SerializeField]
    private Color currentColor;

    // Start is called before the first frame update
    void Start()
    {
        int lastFinished = PlayerPrefs.GetInt(LAST_FINISHED_WORLD, -1);
        CreateButtons(lastFinished);
        worldText.text = "World " + (worldKey + 1);
        ShowAchievements();
        ShowDoneParts();
        
    }

    private void CreateButtons(int lastFinishedWorld) {
        int lastFinishedPiece = PlayerPrefs.GetInt(LAST_FINISHED_PIECE + worldKey, -1);

        for (int i = 0; i < 4; i++) {
            var lvl = Instantiate(levelButtonPrefab, levelsParent);
            lvl.SetWorldAndNumber(worldKey, i);
            if(worldKey > lastFinishedWorld + 1) {
                lvl.SetLocked();
            } else if(worldKey == lastFinishedWorld + 1){
                if (i <= lastFinishedPiece)
                    lvl.SetDone(); 
                else if(i == lastFinishedPiece+1) {
                    lvl.SetCurrent();
                } else {
                    lvl.SetLocked();
                }
            } else {
                lvl.SetDone();
            }
        }
    }

    private void ShowAchievements() {
        achievementImages[0].color = AchievementHolder.Instance.IsAchieved(Achievement.Done, worldKey) ? doneColor : currentColor; 
        achievementImages[1].color = AchievementHolder.Instance.IsAchieved(Achievement.Star, worldKey) ? doneColor : currentColor;
        //achievementImages[2].color = AchievementHolder.Instance.IsAchieved(Achievement.FirstTake, worldKey) ? doneColor : currentColor;
    }

    private void ShowDoneParts() {
        int lastFinishedPiece = PlayerPrefs.GetInt(LAST_FINISHED_PIECE+worldKey, -1);

        for (int i = 0; i < levelButtons.Count; i++) {
            if (i > lastFinishedPiece)
                levelButtons[i].SetDone();
            
        }
    }
}
