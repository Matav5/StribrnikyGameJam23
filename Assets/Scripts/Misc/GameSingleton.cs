//  <copyright file="GameSingleton.cs" company="Xinity">
//  Copyright (c) 2013 All Right Reserved, http://xinity.com/
// 
//  </copyright>
//  <author>Pavel</author>
//  <email>pavel.fadrhonc@xinity.com</email>
//  <date>12/8/2013 11:26:46 PM</date>
//  <summary>Differs from SceneSingleton in that it is not destroyed on new scene load
// and is persistent throughout the whole game.
// However, </summary>
using UnityEngine;

public class GameSingleton<T> : SceneSingleton<T> where T : OakMonoBehaviour
{
    #region UNITY METHODS

    protected override void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            _instance = GetComponent<T>();
        }
        base.Awake();

        DontDestroyOnLoad(this);
    }

    #endregion
}

