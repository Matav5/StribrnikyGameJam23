using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AchievementHolder : GameSingleton<AchievementHolder>
{
    Dictionary<Achievement, string> keys = new Dictionary<Achievement, string>() {
        { Achievement.Done, "AchievementDone"},
        { Achievement.Star, "AchievementStar"},
        { Achievement.FirstTake, "AchievementFirstTake"}
    
    };

    private int currentWorld;
    private bool diedAlready;

    public void StartWorld(int world) {
        currentWorld = world;
        diedAlready = false;
    }

    public void PlayerDied() { diedAlready = true; }

    public void WorldDone() {
        Achieve(Achievement.Done, currentWorld);
        if(!diedAlready)
            Achieve(Achievement.FirstTake, currentWorld);
    }

    public void StarCollected() {
        Achieve(Achievement.Star, currentWorld);
    }

    internal bool IsAchieved(Achievement ach, int worldKey) {
        return PlayerPrefs.HasKey(keys[ach] + worldKey);
    }

    public void Achieve(Achievement ach, int worldKey) {
        PlayerPrefs.SetInt(keys[ach] + worldKey, 1);
    }
}

public enum Achievement
{
    Done, Star, FirstTake
}
